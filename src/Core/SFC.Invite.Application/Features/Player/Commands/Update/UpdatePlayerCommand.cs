using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Player.Commands.Update;
public class UpdatePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}
