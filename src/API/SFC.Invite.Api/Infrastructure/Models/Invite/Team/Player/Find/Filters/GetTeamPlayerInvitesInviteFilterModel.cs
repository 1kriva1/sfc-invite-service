using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Find.Filters;

/// <summary>
/// Get team player invites for invite filter model.
/// </summary>
public class GetTeamPlayerInvitesInviteFilterModel : IMapTo<GetTeamPlayerInvitesInviteFilterDto>
{
    /// <summary>
    /// Statuses of invite.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}