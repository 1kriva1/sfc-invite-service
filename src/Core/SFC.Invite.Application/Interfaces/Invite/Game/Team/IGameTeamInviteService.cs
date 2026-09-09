using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Interfaces.Invite.Game.Team;
public interface IGameTeamInviteService
{
    Task NotifyGameTeamInviteCreatedAsync(GameTeamInvite invite, CancellationToken cancellationToken = default);

    Task NotifyGameTeamInviteUpdatedAsync(GameTeamInvite invite, CancellationToken cancellationToken = default);
}