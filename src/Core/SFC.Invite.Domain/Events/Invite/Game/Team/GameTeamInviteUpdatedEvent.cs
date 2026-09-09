using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Domain.Events.Invite.Game.Team;
public class GameTeamInviteUpdatedEvent(GameTeamInvite entity) : BaseEvent
{
    public GameTeamInvite Invite { get; } = entity;
}