using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Events.Player;
public class PlayersCreatedEvent(IEnumerable<PlayerEntity> players) : BaseEvent
{
    public IEnumerable<PlayerEntity> Players { get; } = players;
}
