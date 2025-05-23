using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Events.Team.General;
public class TeamsCreatedEvent(IEnumerable<TeamEntity> teams) : BaseEvent
{
    public IEnumerable<TeamEntity> Teams { get; } = teams;
}