using SFC.Invite.Application.Common.Dto.Team.Player;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Team.Player.Commands.CreateRange;
public class CreateTeamPlayersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayers; }

    public IEnumerable<TeamPlayerDto> TeamPlayers { get; set; } = null!;
}