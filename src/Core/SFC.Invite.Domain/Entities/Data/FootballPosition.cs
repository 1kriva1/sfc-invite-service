using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Data;
public class FootballPosition : EnumDataEntity<FootballPositionEnum>
{
    public FootballPosition() : base() { }

    public FootballPosition(FootballPositionEnum enumType) : base(enumType) { }
}
