using SFC.Invite.Messages.Commands.Common;
using SFC.Invite.Messages.Models.Invite.Game.Player;

namespace SFC.Invite.Messages.Commands.Invite.Game.Player;
public class SeedGamePlayerInvites : InitiatorCommand
{
    public IEnumerable<GamePlayerInvite> GamePlayerInvites { get; init; } = [];
}