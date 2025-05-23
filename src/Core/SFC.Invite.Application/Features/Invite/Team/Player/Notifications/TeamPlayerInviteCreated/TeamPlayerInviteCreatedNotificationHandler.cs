using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Domain.Events.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Notifications.TeamPlayerInviteCreated;
public class TeamPlayerInviteCreatedNotificationHandler(ITeamPlayerInviteService teamPlayerInviteService) : INotificationHandler<TeamPlayerInviteCreatedEvent>
{
    private readonly ITeamPlayerInviteService _teamPlayerInviteService = teamPlayerInviteService;

    public Task Handle(TeamPlayerInviteCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _teamPlayerInviteService.NotifyTeamPlayerInviteCreatedAsync(notification.Invite, cancellationToken);
    }
}