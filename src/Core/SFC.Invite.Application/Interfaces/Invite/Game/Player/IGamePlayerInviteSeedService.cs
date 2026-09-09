using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Interfaces.Invite.Game.Player;
public interface IGamePlayerInviteSeedService
{
    Task<IEnumerable<GamePlayerInvite>> GetSeedGamePlayerInvitesAsync();

    Task SeedGamePlayerInvitesAsync(CancellationToken cancellationToken = default);
}