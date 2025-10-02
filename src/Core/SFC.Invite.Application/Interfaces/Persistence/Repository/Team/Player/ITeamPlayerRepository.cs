using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Player;
public interface ITeamPlayerRepository : IRepository<TeamPlayer, ITeamDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long teamId, long playerId);

    Task<bool> AnyAsync(long teamId, long playerId, TeamPlayerStatusEnum status);

    Task<TeamPlayer?> GetByIdAsync(long teamId, long playerId);

    Task<TeamPlayer[]> AddRangeIfNotExistsAsync(params TeamPlayer[] entities);
}