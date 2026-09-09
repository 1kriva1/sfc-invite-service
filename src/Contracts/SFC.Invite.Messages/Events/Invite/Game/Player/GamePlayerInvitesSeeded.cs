using SFC.Invite.Messages.Models.Invite.Game.Player;

namespace SFC.Invite.Messages.Events.Invite.Game.Player;
public class GamePlayerInvitesSeeded
{
    public IEnumerable<GamePlayerInvite> GamePlayerInvites { get; init; } = [];
}