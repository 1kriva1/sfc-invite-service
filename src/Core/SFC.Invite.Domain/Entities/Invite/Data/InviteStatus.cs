using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Invite.Data;
public class InviteStatus : EnumDataEntity<InviteStatusEnum>
{
    public InviteStatus() : base() { }

    public InviteStatus(InviteStatusEnum enumType) : base(enumType) { }
}