using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Game.Data;
public class GameTeamStatus : EnumDataEntity<GameTeamStatusEnum>
{
    public GameTeamStatus() : base() { }

    public GameTeamStatus(GameTeamStatusEnum enumType) : base(enumType) { }
}