using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Exist;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Exist;

/// <summary>
/// Described the result of check if team player invite **exist**.
/// </summary>
public class TeamPlayerInviteExistResponse : BaseResponse, IMapFrom<TeamPlayerInviteExistViewModel>
{
    /// <summary>
    /// Determined if team player invite exist.
    /// </summary>
    public bool Exist { get; set; }
}