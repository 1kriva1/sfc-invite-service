using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Team.General;
public abstract class BaseTeamEntity : BaseEntity<long>
{
    public TeamEntity Team { get; set; } = null!;
}