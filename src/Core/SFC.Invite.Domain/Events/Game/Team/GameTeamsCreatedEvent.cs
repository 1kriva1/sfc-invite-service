using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Game.Team;

namespace SFC.Invite.Domain.Events.Game.Team;
public class GameTeamsCreatedEvent(IEnumerable<GameTeam> gameTeams) : BaseEvent
{
    public IEnumerable<GameTeam> GameTeams { get; } = gameTeams;
}