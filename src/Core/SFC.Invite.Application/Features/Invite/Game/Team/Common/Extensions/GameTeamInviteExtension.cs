using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Common.Extensions;
public static class GameTeamInviteExtension
{
    public static GameTeamInvite SetStatus(this GameTeamInvite value, InviteStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}