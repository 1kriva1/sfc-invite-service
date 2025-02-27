using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Data;
public class StatType : EnumDataEntity<StatTypeEnum>
{
    public StatType() : base() { }

    public StatType(StatTypeEnum enumType) : base(enumType) { }

    public StatCategoryEnum CategoryId { get; set; }

    public StatSkillEnum SkillId { get; set; }
}
