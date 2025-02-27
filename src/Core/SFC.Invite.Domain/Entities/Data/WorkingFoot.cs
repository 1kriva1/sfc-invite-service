using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Data;
public class WorkingFoot : EnumDataEntity<WorkingFootEnum>
{
    public WorkingFoot() : base() { }

    public WorkingFoot(WorkingFootEnum enumType) : base(enumType) { }
}
