using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Common.Extensions;
public static class TeamPlayerInviteExtension
{
    public static TeamPlayerInvite SetStatus(this TeamPlayerInvite value, InviteStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}