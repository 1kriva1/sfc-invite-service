using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Interfaces.Invite.Team.Player;
public interface ITeamPlayerInviteService
{
    Task NotifyTeamPlayerInviteCreatedAsync(TeamPlayerInvite invite, CancellationToken cancellationToken = default);

    Task NotifyTeamPlayerInviteUpdatedAsync(TeamPlayerInvite invite, CancellationToken cancellationToken = default);
}