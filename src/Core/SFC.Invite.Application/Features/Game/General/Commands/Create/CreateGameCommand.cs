using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.General.Commands.Create;
public class CreateGameCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGame; }

    public GameDto Game { get; set; } = null!;
}