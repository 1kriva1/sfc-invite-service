using SFC.Invite.Messages.Models.Invite.Game.Player;

namespace SFC.Invite.Messages.Events.Invite.Game.Player;
public class GamePlayerInviteUpdated
{
    public required GamePlayerInvite Invite { get; set; }
}