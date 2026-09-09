using SFC.Invite.Application.Common.Dto.Game.Player;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.Player.Commands.Update;
public class UpdateGamePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGamePlayer; }

    public required GamePlayerDto GamePlayer { get; set; }
}