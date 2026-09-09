using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGameTeamInviteRepository : IRepository<GameTeamInvite, IInviteDbContext, long>
{
    Task<GameTeamInvite?> GetByIdAsync(long id, long gameId, long teamId);

    Task<IEnumerable<GameTeamInvite>> GetByIdsAsync(IEnumerable<long> ids);

    Task<IEnumerable<GameTeamInvite>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> teamIds);

    Task<IReadOnlyList<GameTeamInvite>> ListAllAsync(long gameId);

    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<bool> AnyAsync(long gameId, long teamId, InviteStatusEnum? status);

    Task<GameTeamInvite[]> AddRangeIfNotExistsAsync(params GameTeamInvite[] entities);
}