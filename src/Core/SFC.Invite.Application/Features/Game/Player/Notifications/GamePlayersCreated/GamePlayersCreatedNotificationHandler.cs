using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Invite.Application.Interfaces.Invite.Game.Player;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Domain.Events.Game.Player;

namespace SFC.Invite.Application.Features.Game.Player.Notifications.GamePlayersCreated;
public class GamePlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGamePlayerInviteSeedService gamePlayerInviteSeedService) : INotificationHandler<GamePlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGamePlayerInviteSeedService _gamePlayerInviteSeedService = gamePlayerInviteSeedService;

    public async Task Handle(GamePlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GamePlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.GamePlayerInvite, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _gamePlayerInviteSeedService.SeedGamePlayerInvitesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}