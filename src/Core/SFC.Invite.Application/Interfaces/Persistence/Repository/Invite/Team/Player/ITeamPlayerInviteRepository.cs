using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface ITeamPlayerInviteRepository : IRepository<TeamPlayerInvite, IInviteDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<bool> AnyAsync(long teamId, long playerId, InviteStatusEnum status);

    Task<TeamPlayerInvite?> GetByIdAsync(long id, long teamId, long playerId);

    Task<IEnumerable<TeamPlayerInvite>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds);

    Task<TeamPlayerInvite[]> AddRangeIfNotExistsAsync(params TeamPlayerInvite[] entities);
}