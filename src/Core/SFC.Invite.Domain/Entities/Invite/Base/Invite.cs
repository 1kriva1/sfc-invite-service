using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Invite.Base;

/// <summary>
/// Core entity of the service.
/// </summary>
public abstract class Invite : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public InviteStatusEnum StatusId { get; set; }
}
