using SFC.Invite.Messages.Models.Invite.Team.Player;

namespace SFC.Invite.Messages.Events.Invite.Team.Player;
public class TeamPlayerInviteUpdated
{
    public required TeamPlayerInvite Invite { get; set; }
}