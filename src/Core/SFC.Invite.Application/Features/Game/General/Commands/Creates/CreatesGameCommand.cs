using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.General.Commands.Creates;
public class CreatesGameCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGames; }

    public IEnumerable<GameDto> Games { get; set; } = null!;
}