using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Domain.Events.Invite.Game.Player;
public class GamePlayerInviteUpdatedEvent(GamePlayerInvite entity) : BaseEvent
{
    public GamePlayerInvite Invite { get; } = entity;
}