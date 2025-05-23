using SFC.Invite.Messages.Commands.Common;
using SFC.Invite.Messages.Models.Invite.Team.Player;

namespace SFC.Invite.Messages.Commands.Invite.Team.Player;
public class SeedTeamPlayerInvites : InitiatorCommand
{
    public IEnumerable<TeamPlayerInvite> TeamPlayerInvites { get; init; } = [];
}