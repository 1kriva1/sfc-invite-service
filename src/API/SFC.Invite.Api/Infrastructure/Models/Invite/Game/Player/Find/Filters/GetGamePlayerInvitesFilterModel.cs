using SFC.Invite.Api.Infrastructure.Models.Player.Find.Filters;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Find.Filters;

/// <summary>
/// Get Game player invites filter model.
/// </summary>
public class GetGamePlayerInvitesFilterModel : IMapTo<GetGamePlayerInvitesFilterDto>
{
    /// <summary>
    /// Invite filter model.
    /// </summary>
    public GetGamePlayerInvitesInviteFilterModel? Invite { get; set; }

    /// <summary>
    /// Player filter model.
    /// </summary>
    public PlayerFilterModel? Player { get; set; }
}