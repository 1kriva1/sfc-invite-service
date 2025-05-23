using SFC.Invite.Messages.Models.Invite.Team.Player;

namespace SFC.Invite.Messages.Events.Invite.Team.Player;
public class TeamPlayerInvitesSeeded
{
    public IEnumerable<TeamPlayerInvite> TeamPlayerInvites { get; init; } = [];
}