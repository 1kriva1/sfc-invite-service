using SFC.Invite.Messages.Models.Invite.Game.Team;

namespace SFC.Invite.Messages.Events.Invite.Game.Team;
public class GameTeamInviteUpdated
{
    public required GameTeamInvite Invite { get; set; }
}