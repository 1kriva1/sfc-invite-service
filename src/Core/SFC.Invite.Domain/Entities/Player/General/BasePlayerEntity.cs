using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Player.General;
public abstract class BasePlayerEntity : BaseEntity<long>
{
    public PlayerEntity Player { get; set; } = null!;
}