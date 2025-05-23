using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Domain.Events.Invite.Team.Player;
public class TeamPlayerInviteUpdatedEvent(TeamPlayerInvite entity) : BaseEvent
{
    public TeamPlayerInvite Invite { get; } = entity;
}