using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Game.Team;
public class GameTeamInviteRepository(InviteDbContext context)
    : Repository<GameTeamInvite, InviteDbContext, long>(context), IGameTeamInviteRepository
{
    #region Public

    public override Task<GameTeamInvite?> GetByIdAsync(long id)
    {
        return Context.GameTeamInvites
                     .ThanIncludeTeam()
                     .ThanIncludeGame()
                     .FirstOrDefaultAsync(invite => invite.Id == id);
    }

    public Task<GameTeamInvite?> GetByIdAsync(long id, long gameId, long teamId)
    {
        return Context.GameTeamInvites
                      .ThanIncludeTeam()
                      .ThanIncludeGame()
                      .FirstOrDefaultAsync(invite => invite.Id == id && invite.GameId == gameId && invite.Team.Id == teamId);
    }

    public async Task<IEnumerable<GameTeamInvite>> GetByIdsAsync(IEnumerable<long> ids)
    {
        return await Context.GameTeamInvites
                            .ThanIncludeTeam()
                            .ThanIncludeGame()
                            .Where(invite => ids.Contains(invite.Id))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IEnumerable<GameTeamInvite>> GetByIdsAsync(IEnumerable<long> gameIds, IEnumerable<long> teamIds)
    {
        return await Context.GameTeamInvites
                            .Where(invite => gameIds.Contains(invite.GameId) && teamIds.Contains(invite.TeamId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<GameTeamInvite>> ListAllAsync(long gameId)
    {
        return await Context.GameTeamInvites
                            .ThanIncludeTeam()
                            .ThanIncludeGame()
                            .Where(gameTeam => gameTeam.GameId == gameId)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GameTeamInvites.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.GameTeamInvites.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public Task<bool> AnyAsync(long gameId, long teamId, InviteStatusEnum? status)
    {
        return status.HasValue
            ? Context.GameTeamInvites.AnyAsync(invite => invite.GameId == gameId && invite.StatusId == status && invite.Team.Id == teamId)
            : Context.GameTeamInvites.AnyAsync(invite => invite.GameId == gameId && invite.Team.Id == teamId);
    }

    public async Task<GameTeamInvite[]> AddRangeIfNotExistsAsync(params GameTeamInvite[] entities)
    {
        await Context.Set<GameTeamInvite>().AddRangeIfNotExistsAsync<GameTeamInvite, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<PagedList<GameTeamInvite>> FindAsync(FindParameters<GameTeamInvite> parameters)
    {
        return Context.GameTeamInvites
                      .ThanIncludeTeam()
                      .ThanIncludeGame()
                      .AsQueryable<GameTeamInvite>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}