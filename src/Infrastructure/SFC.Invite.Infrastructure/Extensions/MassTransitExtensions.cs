using System.Reflection;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.Identity.Messages.Commands.User;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Messages.Commands.Common;
using SFC.Invite.Messages.Commands.Invite.Team.Player;
using SFC.Invite.Messages.Events.Invite.Data;
using SFC.Invite.Messages.Events.Invite.Team.Player;
using SFC.Player.Messages.Commands.Player;
using SFC.Team.Messages.Commands.Team.General;
using SFC.Team.Messages.Commands.Team.Player;

namespace SFC.Invite.Infrastructure.Extensions;
public static class MassTransitExtensions
{
    private const string EXCHANGE_ENDPOINT_SHORT_ADDRESS = "exchange";
    private const string EXCHANGE_ENDPOINT_AUTO_DELETE_PART = "autodelete";

    #region Public

    public static IServiceCollection AddMassTransit(this WebApplicationBuilder builder)
    {
        return builder.Services.AddMassTransit(masTransitConfigure =>
        {
            masTransitConfigure.AddConsumers(Assembly.GetExecutingAssembly());

            masTransitConfigure.UsingRabbitMq((context, rabbitMqConfigure) =>
            {
                RabbitMqSettings settings = builder.Configuration.GetRabbitMqSettings();

                string rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMq")!;

                rabbitMqConfigure.Host(new Uri(rabbitMqConnectionString), settings.Name, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                rabbitMqConfigure.UseRetries(settings.Retry);

                rabbitMqConfigure.AddExchanges(builder.Environment, settings.Exchanges);

                rabbitMqConfigure.ConfigureEndpoints(context);

                MapEndpoints(settings.Exchanges, builder.Environment);
            });
        });
    }

    public static string BuildExchangeRoutingKey(this string initiator, string key)
        => $"{key.ToLower(System.Globalization.CultureInfo.CurrentCulture)}.{initiator.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)}";

    #endregion Public

    #region Private

    private static void AddExchanges(
        this IRabbitMqBusFactoryConfigurator configure,
        IWebHostEnvironment environment,
        RabbitMqExchangesSettings exchangesSettings)
    {
        // "sfc.invite.data.initialized"
        configure.AddExchange<DataInitialized>(exchangesSettings.Invite.Value.Data.Source.Initialized);

        // "sfc.invite.team.player.created"
        configure.AddExchange<TeamPlayerInviteCreated>(exchangesSettings.Invite.Value.Domain.Team.Player.Events.Created);

        // "sfc.invite.team.player.updated"
        configure.AddExchange<TeamPlayerInviteUpdated>(exchangesSettings.Invite.Value.Domain.Team.Player.Events.Updated,
            context => Enum.GetName(typeof(InviteStatusEnum), context.Message.Invite.StatusId));

        if (environment.IsDevelopment())
        {
            // "sfc.invite.team.player.seed"
            configure.AddExchange<SeedTeamPlayerInvites>(exchangesSettings.Invite.Value.Domain.Team.Player.Seed.Seed, exchangesSettings.Invite.Key);
        }
    }

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings, IWebHostEnvironment environment)
    {
        EndpointConvention.Map<SFC.Invite.Messages.Commands.Data.RequireData>(exchangesSettings.Invite.Value.Data.Dependent.Data.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Invite.Messages.Commands.Team.Data.RequireData>(exchangesSettings.Invite.Value.Data.Dependent.Team.RequireInitialize.GetExchangeEndpointUri());

        EndpointConvention.Map<SFC.Team.Messages.Commands.Invite.Data.InitializeData>(exchangesSettings.Team.Value.Data.Dependent.Invite.Initialize.GetExchangeEndpointUri());

        if (environment.IsDevelopment())
        {
            // "sfc.identity.users.seed.require"
            EndpointConvention.Map<RequireUsersSeed>(exchangesSettings.Identity.Value.Domain.User.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.player.players.seed.require"
            EndpointConvention.Map<RequirePlayersSeed>(exchangesSettings.Player.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.team.teams.seed.require"
            EndpointConvention.Map<RequireTeamsSeed>(exchangesSettings.Team.Value.Domain.Team.Seed.RequireSeed.GetExchangeEndpointUri());

            // "sfc.team.player.seed.require"
            EndpointConvention.Map<RequireTeamPlayersSeed>(exchangesSettings.Team.Value.Domain.Player.Seed.RequireSeed.GetExchangeEndpointUri());
        }
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange)
        where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, Func<SendContext<T>, string?> formatter)
        where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(formatter));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange, string key)
        where T : InitiatorCommand
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(context => context.Message.Initiator.BuildExchangeRoutingKey(key)));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void UseRetries(this IRabbitMqBusFactoryConfigurator configure, RabbitMqRetrySettings settings)
    {
        configure.UseDelayedRedelivery(r =>
            r.Intervals(settings.Intervals.Select(i => TimeSpan.FromMinutes(i)).ToArray()));
        configure.UseMessageRetry(r => r.Immediate(settings.Limit));
    }

    private static Uri GetExchangeEndpointUri(this Message exchange) =>
       new($"{EXCHANGE_ENDPOINT_SHORT_ADDRESS}:{exchange.Name}?{EXCHANGE_ENDPOINT_AUTO_DELETE_PART}={true}");

    #endregion Private
}