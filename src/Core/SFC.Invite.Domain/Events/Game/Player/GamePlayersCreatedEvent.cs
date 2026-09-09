using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Game.Player;

namespace SFC.Invite.Domain.Events.Game.Player;
public class GamePlayersCreatedEvent(IEnumerable<GamePlayer> gamePlayers) : BaseEvent
{
    public IEnumerable<GamePlayer> GamePlayers { get; } = gamePlayers;
}