using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Exist;

public class GameTeamInviteExistQuery : Request<GameTeamInviteExistViewModel>
{
    public override RequestId RequestId { get => RequestId.ExistGameTeamInvite; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public InviteStatusEnum? Status { get; set; }

    public GameTeamInviteExistQuery SetTeamId(long teamId)
    {
        this.TeamId = teamId;
        return this;
    }

    public GameTeamInviteExistQuery SetGameId(long gameId)
    {
        this.GameId = gameId;
        return this;
    }
}