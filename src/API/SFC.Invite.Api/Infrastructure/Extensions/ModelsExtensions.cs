using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;
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

    public static UpdateGamePlayerInviteCommand BuildUpdateGamePlayerInviteCommand(this InviteStatusEnum status, long id, long gameId, long playerId)
    {
        return new()
        {
            Invite = new UpdateGamePlayerInviteDto
            {
                Id = id,
                GameId = gameId,
                PlayerId = playerId,
                Status = (int)status
            }
        };
    }

    public static UpdateGameTeamInviteCommand BuildUpdateGameTeamInviteCommand(this InviteStatusEnum status, long id, long gameId, long teamId)
    {
        return new()
        {
            Invite = new UpdateGameTeamInviteDto
            {
                Id = id,
                GameId = gameId,
                TeamId = teamId,
                Status = (int)status
            }
        };
    }
}