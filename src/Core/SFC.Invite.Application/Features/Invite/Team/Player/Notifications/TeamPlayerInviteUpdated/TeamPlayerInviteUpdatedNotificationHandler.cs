using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Domain.Events.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Notifications.TeamPlayerInviteUpdated;
public class TeamPlayerInviteUpdatedNotificationHandler(ITeamPlayerInviteService teamPlayerInviteService) : INotificationHandler<TeamPlayerInviteUpdatedEvent>
{
    private readonly ITeamPlayerInviteService _teamPlayerInviteService = teamPlayerInviteService;

    public Task Handle(TeamPlayerInviteUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _teamPlayerInviteService.NotifyTeamPlayerInviteUpdatedAsync(notification.Invite, cancellationToken);
    }
}