using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Data;
public class StatCategory : EnumDataEntity<StatCategoryEnum>
{
    public StatCategory() : base() { }

    public StatCategory(StatCategoryEnum enumType) : base(enumType) { }

    public ICollection<StatType> Types { get; init; } = [];
}
