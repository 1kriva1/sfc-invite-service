using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.General.Commands.Update;
public class UpdateGameCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGame; }

    public GameDto Game { get; set; } = null!;
}