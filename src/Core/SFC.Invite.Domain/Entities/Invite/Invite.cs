using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Invite;

/// <summary>
/// Core entity of the service.
/// </summary>
public class Invite : BaseAuditableEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }
}
