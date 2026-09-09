using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Invite.Application.Interfaces.Invite.Game.Team;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Domain.Events.Game.Team;

namespace SFC.Invite.Application.Features.Game.Team.Notifications.GameTeamsCreated;
public class GameTeamsCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    IGameTeamInviteSeedService gameTeamInviteSeedService) : INotificationHandler<GameTeamsCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly IGameTeamInviteSeedService _gameTeamInviteSeedService = gameTeamInviteSeedService;

    public async Task Handle(GameTeamsCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.GameTeam, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.GameTeamInvite, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _gameTeamInviteSeedService.SeedGameTeamInvitesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}