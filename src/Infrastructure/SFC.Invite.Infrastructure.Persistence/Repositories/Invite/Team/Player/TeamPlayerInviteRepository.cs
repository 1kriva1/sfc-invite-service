using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Team.Player;
public class TeamPlayerInviteRepository(InviteDbContext context)
    : Repository<TeamPlayerInvite, InviteDbContext, long>(context), ITeamPlayerInviteRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.TeamPlayerInvites.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.TeamPlayerInvites.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public Task<bool> AnyAsync(long teamId, long playerId, InviteStatusEnum status)
    {
        return Context.TeamPlayerInvites.AnyAsync(invite =>
            invite.TeamId == teamId &&
            invite.StatusId == status &&
            invite.Player.Id == playerId);
    }

    public Task<TeamPlayerInvite?> GetByIdAsync(long id, long teamId, long playerId)
    {
        return Context.TeamPlayerInvites
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo)
                      .FirstOrDefaultAsync(invite => invite.Id == id && invite.TeamId == teamId && invite.Player.Id == playerId);
    }

    public async Task<IEnumerable<TeamPlayerInvite>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds)
    {
        return await Context.TeamPlayerInvites
                            .Where(invite => teamIds.Contains(invite.TeamId) && playerIds.Contains(invite.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
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
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo)
                      .AsQueryable<TeamPlayerInvite>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}