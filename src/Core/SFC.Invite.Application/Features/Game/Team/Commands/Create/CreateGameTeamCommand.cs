using SFC.Invite.Application.Common.Dto.Game.Team;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.Team.Commands.Create;
public class CreateGameTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGameTeam; }

    public required GameTeamDto GameTeam { get; set; }
}