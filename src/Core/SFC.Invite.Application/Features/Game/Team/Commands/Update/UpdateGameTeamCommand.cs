using SFC.Invite.Application.Common.Dto.Game.Team;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.Team.Commands.Update;
public class UpdateGameTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeam; }

    public required GameTeamDto GameTeam { get; set; }
}