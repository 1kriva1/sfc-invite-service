using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Exist;

public class TeamPlayerInviteExistQuery : Request<TeamPlayerInviteExistViewModel>
{
    public override RequestId RequestId { get => RequestId.TeamPlayerInviteExist; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public InviteStatusEnum? Status { get; set; }

    public TeamPlayerInviteExistQuery SetPlayerId(long playerId)
    {
        this.PlayerId = playerId;
        return this;
    }

    public TeamPlayerInviteExistQuery SetTeamId(long teamId)
    {
        this.TeamId = teamId;
        return this;
    }
}