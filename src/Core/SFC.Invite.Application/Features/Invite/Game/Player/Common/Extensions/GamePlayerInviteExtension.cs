using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Common.Extensions;
public static class GamePlayerInviteExtension
{
    public static GamePlayerInvite SetStatus(this GamePlayerInvite value, InviteStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}