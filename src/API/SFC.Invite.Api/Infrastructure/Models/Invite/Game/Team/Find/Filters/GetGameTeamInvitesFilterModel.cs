using SFC.Invite.Api.Infrastructure.Models.Team.General.Filters;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Find.Filters;

/// <summary>
/// Get Game Team invites filter model.
/// </summary>
public class GetGameTeamInvitesFilterModel : IMapTo<GetGameTeamInvitesFilterDto>
{
    /// <summary>
    /// Invite filter model.
    /// </summary>
    public GetGameTeamInvitesInviteFilterModel? Invite { get; set; }

    /// <summary>
    /// Team filter model.
    /// </summary>
    public TeamFilterModel? Team { get; set; }
}