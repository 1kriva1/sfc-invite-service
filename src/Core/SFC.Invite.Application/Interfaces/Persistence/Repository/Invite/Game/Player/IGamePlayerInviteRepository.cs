using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGamePlayerInviteRepository : IRepository<GamePlayerInvite, IInviteDbContext, long>
{
    Task<GamePlayerInvite?> GetByIdAsync(long id, long gameId, long playerId);

    Task<IEnumerable<GamePlayerInvite>> GetByIdsAsync(IEnumerable<long> ids);

    Task<IEnumerable<GamePlayerInvite>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> playerIds);

    Task<IReadOnlyList<GamePlayerInvite>> ListAllAsync(long gameId);

    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<bool> AnyAsync(long gameId, long playerId, InviteStatusEnum? status);

    Task<GamePlayerInvite[]> AddRangeIfNotExistsAsync(params GamePlayerInvite[] entities);
}