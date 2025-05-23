using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Extensions;

public static class ModelsExtensions
{
    public static UpdateTeamPlayerInviteCommand BuildUpdateTeamPlayerInviteCommand(this InviteStatusEnum status, long id, long teamId, long playerId)
    {
        return new()
        {
            Invite = new UpdateTeamPlayerInviteDto
            {
                Id = id,
                TeamId = teamId,
                PlayerId = playerId,
                Status = (int)status
            }
        };
    }
}