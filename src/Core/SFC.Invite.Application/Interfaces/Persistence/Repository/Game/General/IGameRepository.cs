using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
public interface IGameRepository : IRepository<GameEntity, IGameDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<GameEntity[]> AddRangeIfNotExistsAsync(params GameEntity[] entities);
}