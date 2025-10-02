using Microsoft.EntityFrameworkCore;

using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Infrastructure.Persistence.Extensions;
public static class IncludeExtensions
{
    #region Player

    public static IQueryable<PlayerEntity> IncludePlayer(this IQueryable<PlayerEntity> players)
    {
        IQueryable<PlayerEntity> result = players
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.FootballProfile)
                    .Include(p => p.Availability)
                    .Include(p => p.Availability.Days)
                    .Include(p => p.Points)
                    .Include(p => p.Tags)
                    .Include(p => p.Stats)
                    .Include(p => p.Photo);

        return result;
    }

    #endregion Player

    #region Team

    public static IQueryable<TeamEntity> IncludeTeam(this IQueryable<TeamEntity> teams)
    {
        IQueryable<TeamEntity> result = teams
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.InventaryProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Shirts)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Logo)
                    .Include(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Points)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<TeamPlayer> ThanIncludePlayer(this IQueryable<TeamPlayer> teamPlayers)
    {
        IQueryable<TeamPlayer> result = teamPlayers
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    #endregion Team

    #region Invite

    public static IQueryable<TeamPlayerInvite> ThanIncludePlayer(this IQueryable<TeamPlayerInvite> teamPlayerInvites)
    {
        IQueryable<TeamPlayerInvite> result = teamPlayerInvites
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<TeamPlayerInvite> ThanIncludeTeam(this IQueryable<TeamPlayerInvite> teamPlayerInvites)
    {
        IQueryable<TeamPlayerInvite> result = teamPlayerInvites
                      .Include(x => x.Team).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.FinancialProfile)
                      .Include(x => x.Team).ThenInclude(p => p.InventaryProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Shirts)
                      .Include(x => x.Team).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Logo)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    #endregion Invite
}