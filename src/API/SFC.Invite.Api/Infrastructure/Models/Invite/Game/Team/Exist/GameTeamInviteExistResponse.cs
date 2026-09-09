using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Exist;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Exist;

/// <summary>
/// Described the result of check if Game Team invite **exist**.
/// </summary>
public class GameTeamInviteExistResponse : BaseResponse, IMapFrom<GameTeamInviteExistViewModel>
{
    /// <summary>
    /// Determined if Game Team invite exist.
    /// </summary>
    public bool Exist { get; set; }
}