using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Team.Player;
public class TeamPlayerInviteRepository(InviteDbContext context)
    : Repository<TeamPlayerInvite, InviteDbContext, long>(context), ITeamPlayerInviteRepository
{
    #region Public

    public Task<TeamPlayerInvite?> GetByIdAsync(long id, long teamId, long playerId)
    {
        return Context.TeamPlayerInvites
                      .ThanIncludePlayer()
                      .ThanIncludeTeam()
                      .FirstOrDefaultAsync(invite => invite.Id == id && invite.TeamId == teamId && invite.Player.Id == playerId);
    }

    public async Task<IEnumerable<TeamPlayerInvite>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds)
    {
        return await Context.TeamPlayerInvites
                            .Where(invite => teamIds.Contains(invite.TeamId) && playerIds.Contains(invite.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public async Task<IReadOnlyList<TeamPlayerInvite>> ListAllAsync(long teamId)
    {
        return await Context.TeamPlayerInvites
                            .ThanIncludePlayer()
                            .ThanIncludeTeam()
                            .Where(teamPlayer => teamPlayer.TeamId == teamId)
                            .ToListAsync()
                            .ConfigureAwait(true);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.TeamPlayerInvites.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.TeamPlayerInvites.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId, InviteStatusEnum? status)
    {
        return status.HasValue
            ? Context.TeamPlayerInvites.AnyAsync(invite => invite.TeamId == teamId && invite.StatusId == status && invite.Player.Id == playerId)
            : Context.TeamPlayerInvites.AnyAsync(invite => invite.TeamId == teamId && invite.Player.Id == playerId);
    }

    public async Task<TeamPlayerInvite[]> AddRangeIfNotExistsAsync(params TeamPlayerInvite[] entities)
    {
        await Context.Set<TeamPlayerInvite>().AddRangeIfNotExistsAsync<TeamPlayerInvite, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<PagedList<TeamPlayerInvite>> FindAsync(FindParameters<TeamPlayerInvite> parameters)
    {
        return Context.TeamPlayerInvites
                      .ThanIncludePlayer()
                      .ThanIncludeTeam()
                      .AsQueryable<TeamPlayerInvite>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}