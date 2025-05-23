using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Domain.Entities.Player.General;
public class PlayerStat : BasePlayerEntity
{
    public StatTypeEnum TypeId { get; set; }

    public required StatType Type { get; set; }

    public byte Value { get; set; }
}
