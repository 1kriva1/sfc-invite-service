using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Player;
public abstract class BasePlayerEntity : BaseEntity<long>
{
    public Player Player { get; set; } = null!;
}
