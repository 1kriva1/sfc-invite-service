using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;
public class UpdateTeamPlayerInviteCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeamPlayerInvite; }

    public required UpdateTeamPlayerInviteDto Invite { get; set; }

    public UpdateTeamPlayerInviteCommand SetId(long id)
    {
        this.Invite.Id = id;
        return this;
    }

    public UpdateTeamPlayerInviteCommand SetPlayerId(long playerId)
    {
        this.Invite.PlayerId = playerId;
        return this;
    }

    public UpdateTeamPlayerInviteCommand SetTeamId(long teamId)
    {
        this.Invite.TeamId = teamId;
        return this;
    }

    public UpdateTeamPlayerInviteCommand SetStatus(InviteStatusEnum status)
    {
        this.Invite.Status = (int)status;
        return this;
    }
}