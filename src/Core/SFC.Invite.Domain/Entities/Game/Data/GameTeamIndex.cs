using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Game.Data;
public class GameTeamIndex : EnumDataEntity<GameTeamIndexEnum>
{
    public GameTeamIndex() : base() { }

    public GameTeamIndex(GameTeamIndexEnum enumType) : base(enumType) { }
}