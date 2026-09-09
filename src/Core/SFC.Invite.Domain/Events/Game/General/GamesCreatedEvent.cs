using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Events.Game.General;
public class GamesCreatedEvent(IEnumerable<GameEntity> games) : BaseEvent
{
    public IEnumerable<GameEntity> GameTeams { get; } = games;
}