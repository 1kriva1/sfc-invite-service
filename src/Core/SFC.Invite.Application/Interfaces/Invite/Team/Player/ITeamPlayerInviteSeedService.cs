using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Interfaces.Invite.Team.Player;
public interface ITeamPlayerInviteSeedService
{
    Task<IEnumerable<TeamPlayerInvite>> GetSeedTeamPlayerInvitesAsync();

    Task SeedTeamPlayerInvitesAsync(CancellationToken cancellationToken = default);
}