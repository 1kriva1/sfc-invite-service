using SFC.Invite.Messages.Commands.Common;
using SFC.Invite.Messages.Models.Invite.Game.Team;

namespace SFC.Invite.Messages.Commands.Invite.Game.Team;
public class SeedGameTeamInvites : InitiatorCommand
{
    public IEnumerable<GameTeamInvite> GameTeamInvites { get; init; } = [];
}