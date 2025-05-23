using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Team.Data;
public class TeamPlayerStatus : EnumDataEntity<TeamPlayerStatusEnum>
{
    public TeamPlayerStatus() : base() { }

    public TeamPlayerStatus(TeamPlayerStatusEnum enumType) : base(enumType) { }
}