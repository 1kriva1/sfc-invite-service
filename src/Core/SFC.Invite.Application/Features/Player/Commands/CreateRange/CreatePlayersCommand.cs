using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Player.Commands.CreateRange;
public class CreatePlayersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreatePlayers; }

    public IEnumerable<PlayerDto> Players { get; set; } = null!;
}
