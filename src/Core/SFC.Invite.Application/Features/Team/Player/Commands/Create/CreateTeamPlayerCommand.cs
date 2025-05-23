using SFC.Invite.Application.Common.Dto.Team.Player;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}