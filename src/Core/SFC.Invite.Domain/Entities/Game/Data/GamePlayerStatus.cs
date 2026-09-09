using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Game.Data;
public class GamePlayerStatus : EnumDataEntity<GamePlayerStatusEnum>
{
    public GamePlayerStatus() : base() { }

    public GamePlayerStatus(GamePlayerStatusEnum enumType) : base(enumType) { }
}