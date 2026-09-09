using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Find.Filters;

/// <summary>
/// Get Game player invites for invite filter model.
/// </summary>
public class GetGamePlayerInvitesInviteFilterModel : IMapTo<GetGamePlayerInvitesInviteFilterDto>
{
    /// <summary>
    /// Statuses of invite.
    /// </summary>
    public IEnumerable<int> Statuses { get; set; } = default!;
}