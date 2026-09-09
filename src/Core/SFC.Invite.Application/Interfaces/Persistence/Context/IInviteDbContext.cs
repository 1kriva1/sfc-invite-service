using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface IInviteDbContext : IDbContext
{
    #region General

    IQueryable<TeamPlayerInvite> TeamPlayerInvites { get; }

    IQueryable<GamePlayerInvite> GamePlayerInvites { get; }

    IQueryable<GameTeamInvite> GameTeamInvites { get; }

    #endregion General

    #region Data

    IQueryable<InviteStatus> InviteStatuses { get; }

    #endregion Data
}