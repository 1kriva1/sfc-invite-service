using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Player.Commands.Create;
public class CreatePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}
