using SFC.Invite.Application.Common.Dto.Team.Player;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}