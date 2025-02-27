using SFC.Invite.Application.Interfaces.Persistence.Context;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
public interface IPlayerRepository : IRepository<PlayerEntity, IPlayerDbContext, long>
{
    Task<PlayerEntity[]> AddRangeIfNotExistsAsync(params PlayerEntity[] entities);

    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);
}
