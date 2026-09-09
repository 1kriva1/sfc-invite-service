using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Commands.Game.General;
using SFC.Invite.Application.Features.Game.General.Commands.Creates;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;

namespace SFC.Invite.Infrastructure.Consumers.Game.Domain.Game.Seed;
public class SeedGamesConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedGamesConsumer> logger,
    ISender mediator) : IConsumer<SeedGames>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedGamesConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedGames> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedGames message = context.Message;

            CreatesGameCommand command = _mapper.Map<CreatesGameCommand>(message.Games);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedGamesConsumerDefinition : ConsumerDefinition<SeedGamesConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Game.Seed.Seed; } }

    public SeedGamesConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.game.games.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedGamesConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.player.players.seeded"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Invite.Key.BuildExchangeRoutingKey(_settings.Exchanges.Game.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}