using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Exist;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Exist;

/// <summary>
/// Described the result of check if Game player invite **exist**.
/// </summary>
public class GamePlayerInviteExistResponse : BaseResponse, IMapFrom<GamePlayerInviteExistViewModel>
{
    /// <summary>
    /// Determined if Game player invite exist.
    /// </summary>
    public bool Exist { get; set; }
}