using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Interfaces.Invite.Game.Player;
public interface IGamePlayerInviteService
{
    Task NotifyGamePlayerInviteCreatedAsync(GamePlayerInvite invite, CancellationToken cancellationToken = default);

    Task NotifyGamePlayerInviteUpdatedAsync(GamePlayerInvite invite, CancellationToken cancellationToken = default);
}