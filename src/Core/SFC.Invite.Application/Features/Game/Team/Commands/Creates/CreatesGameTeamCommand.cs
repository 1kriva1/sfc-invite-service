using SFC.Invite.Application.Common.Dto.Game.Team;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Game.Team.Commands.Creates;
public class CreatesGameTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGameTeams; }

    public IEnumerable<GameTeamDto> GameTeams { get; set; } = null!;
}