using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Game.Player;
public class GamePlayerInviteRepository(InviteDbContext context)
    : Repository<GamePlayerInvite, InviteDbContext, long>(context), IGamePlayerInviteRepository
{
    #region Public

    public override Task<GamePlayerInvite?> GetByIdAsync(long id)
    {
        return Context.GamePlayerInvites
                     .ThanIncludePlayer()
                     .ThanIncludeGame()
                     .FirstOrDefaultAsync(invite => invite.Id == id);
    }

    public Task<GamePlayerInvite?> GetByIdAsync(long id, long gameId, long playerId)
    {
        return Context.GamePlayerInvites
                      .ThanIncludePlayer()
                      .ThanIncludeGame()
                      .FirstOrDefaultAsync(invite => invite.Id == id && invite.GameId == gameId && invite.Player.Id == playerId);
    }

    public async Task<IEnumerable<GamePlayerInvite>> GetByIdsAsync(IEnumerable<long> ids)
    {
        return await Context.GamePlayerInvites
                            .ThanIncludePlayer()
                            .ThanIncludeGame()
                            .Where(invite => ids.Contains(invite.Id))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IEnumerable<GamePlayerInvite>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> playerIds)
    {
        return await Context.GamePlayerInvites
                            .Where(invite => gameIds.Contains(invite.GameId) && playerIds.Contains(invite.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<GamePlayerInvite>> ListAllAsync(long gameId)
    {
        return await Context.GamePlayerInvites
                            .ThanIncludePlayer()
                            .ThanIncludeGame()
                            .Where(gamePlayer => gamePlayer.GameId == gameId)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GamePlayerInvites.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.GamePlayerInvites.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public Task<bool> AnyAsync(long gameId, long playerId, InviteStatusEnum? status)
    {
        return status.HasValue
            ? Context.GamePlayerInvites.AnyAsync(invite => invite.GameId == gameId && invite.StatusId == status && invite.Player.Id == playerId)
            : Context.GamePlayerInvites.AnyAsync(invite => invite.GameId == gameId && invite.Player.Id == playerId);
    }

    public async Task<GamePlayerInvite[]> AddRangeIfNotExistsAsync(params GamePlayerInvite[] entities)
    {
        await Context.Set<GamePlayerInvite>().AddRangeIfNotExistsAsync<GamePlayerInvite, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<PagedList<GamePlayerInvite>> FindAsync(FindParameters<GamePlayerInvite> parameters)
    {
        return Context.GamePlayerInvites
                      .ThanIncludePlayer()
                      .ThanIncludeGame()
                      .AsQueryable<GamePlayerInvite>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}