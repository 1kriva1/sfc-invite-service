using SFC.Invite.Api.Infrastructure.Models.Player.Find.Filters;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Find.Filters;

/// <summary>
/// Get team player invites filter model.
/// </summary>
public class GetTeamPlayerInvitesFilterModel : IMapTo<GetTeamPlayerInvitesFilterDto>
{
    /// <summary>
    /// Invite filter model.
    /// </summary>
    public GetTeamPlayerInvitesInviteFilterModel? Invite { get; set; }

    /// <summary>
    /// Player filter model.
    /// </summary>
    public PlayerFilterModel? Player { get; set; }
}