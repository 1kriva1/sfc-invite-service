using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Game.General;
public class GameRepository(GameDbContext context)
    : Repository<GameEntity, GameDbContext, long>(context), IGameRepository
{
    public override Task<GameEntity?> GetByIdAsync(long id)
    {
        return Context.Games
                      .IncludeGame()
                      .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<GameEntity[]> AddRangeIfNotExistsAsync(params GameEntity[] entities)
    {
        await Context.Set<GameEntity>().AddRangeIfNotExistsAsync<GameEntity, long>(entities).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return entities;
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.Games.AnyAsync(p => p.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Games.AnyAsync(p => p.Id == id && p.UserId == userId);
    }
}