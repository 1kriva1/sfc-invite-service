using AutoMapper;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Data.Models;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Messages.Events.Invite.Data;

namespace SFC.Invite.Infrastructure.Services.Hosted;
public class DataInitializationHostedService(
    ILogger<DataInitializationHostedService> logger,
    IServiceProvider services) : BaseInitializationService(logger)
{
    private readonly IServiceProvider _services = services;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        EventId eventId = new((int)RequestId.InitData, Enum.GetName(RequestId.InitData));
        Action<ILogger, Exception?> logStartExecution = LoggerMessage.Define(LogLevel.Information, eventId,
            "Data Initialization Hosted Service running.");
        logStartExecution(Logger, null);

        using IServiceScope scope = _services.CreateScope();

        // publish invite data
        await PublishDataInitializedAsync(scope, cancellationToken).ConfigureAwait(false);

        // send require data
        SendRequireDataAsync(scope, cancellationToken);
    }

    private static async Task PublishDataInitializedAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        IInviteDataService inviteDataService = scope.ServiceProvider.GetRequiredService<IInviteDataService>();

        GetAllInviteDataModel model = await inviteDataService.GetAllInviteDataAsync().ConfigureAwait(true);

        IMapper mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

        DataInitialized @event = mapper.BuildInviteDataInitializedEvent(model);

        IPublishEndpoint publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }

    private static void SendRequireDataAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        // use bus because it is Initiator (reference to mass transit documentation)
        IBus bus = scope.ServiceProvider.GetRequiredService<IBus>();

        bus.Send(new SFC.Invite.Messages.Commands.Data.RequireData(), cancellationToken);

        bus.Send(new SFC.Invite.Messages.Commands.Team.Data.RequireData(), cancellationToken);
    }
}