using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Game.General;
public abstract class BaseGameEntity : BaseEntity<long>
{
    public GameEntity Game { get; set; } = null!;
}