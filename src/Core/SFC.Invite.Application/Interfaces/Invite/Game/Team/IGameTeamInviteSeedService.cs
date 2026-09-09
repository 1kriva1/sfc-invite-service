using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Interfaces.Invite.Game.Team;
public interface IGameTeamInviteSeedService
{
    Task<IEnumerable<GameTeamInvite>> GetSeedGameTeamInvitesAsync();

    Task SeedGameTeamInvitesAsync(CancellationToken cancellationToken = default);
}