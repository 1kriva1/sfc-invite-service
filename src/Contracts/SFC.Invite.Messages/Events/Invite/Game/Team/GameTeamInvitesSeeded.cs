using SFC.Invite.Messages.Models.Invite.Game.Team;

namespace SFC.Invite.Messages.Events.Invite.Game.Team;
public class GameTeamInvitesSeeded
{
    public IEnumerable<GameTeamInvite> GameTeamInvites { get; init; } = [];
}