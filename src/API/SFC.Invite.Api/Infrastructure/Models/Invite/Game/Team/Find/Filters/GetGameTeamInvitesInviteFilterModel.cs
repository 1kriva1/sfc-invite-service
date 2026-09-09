using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Find.Filters;

/// <summary>
/// Get Game Team invites for invite filter model.
/// </summary>
public class GetGameTeamInvitesInviteFilterModel : IMapTo<GetGameTeamInvitesInviteFilterDto>
{
    /// <summary>
    /// Statuses of invite.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}