using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;
public class UpdateGameTeamInviteCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeamInvite; }

    public required UpdateGameTeamInviteDto Invite { get; set; }

    public UpdateGameTeamInviteCommand SetId(long id)
    {
        this.Invite.Id = id;
        return this;
    }

    public UpdateGameTeamInviteCommand SetTeamId(long teamId)
    {
        this.Invite.TeamId = teamId;
        return this;
    }

    public UpdateGameTeamInviteCommand SetGameId(long gameId)
    {
        this.Invite.GameId = gameId;
        return this;
    }

    public UpdateGameTeamInviteCommand SetStatus(InviteStatusEnum status)
    {
        this.Invite.Status = (int)status;
        return this;
    }
}