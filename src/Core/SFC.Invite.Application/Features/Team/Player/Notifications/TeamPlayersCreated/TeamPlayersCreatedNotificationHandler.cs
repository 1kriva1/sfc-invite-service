using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Domain.Events.Team.Player;

namespace SFC.Invite.Application.Features.Team.Player.Notifications.TeamPlayersCreated;
public class TeamPlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ITeamPlayerInviteSeedService teamPlayerInviteSeedService) : INotificationHandler<TeamPlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ITeamPlayerInviteSeedService _teamPlayerInviteSeedService = teamPlayerInviteSeedService;

    public async Task Handle(TeamPlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Team, MetadataDomainEnum.TeamPlayer, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.TeamPlayerInvite, MetadataTypeEnum.Seed).ConfigureAwait(false))
            {
                await _teamPlayerInviteSeedService.SeedTeamPlayerInvitesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}