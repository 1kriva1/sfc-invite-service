using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Domain.Events.Team.Player;
public class TeamPlayersCreatedEvent(IEnumerable<TeamPlayer> teamPlayers) : BaseEvent
{
    public IEnumerable<TeamPlayer> TeamPlayers { get; } = teamPlayers;
}