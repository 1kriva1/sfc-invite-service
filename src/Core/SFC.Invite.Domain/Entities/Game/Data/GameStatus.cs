using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Game.Data;
public class GameStatus : EnumDataEntity<GameStatusEnum>
{
    public GameStatus() : base() { }

    public GameStatus(GameStatusEnum enumType) : base(enumType) { }
}