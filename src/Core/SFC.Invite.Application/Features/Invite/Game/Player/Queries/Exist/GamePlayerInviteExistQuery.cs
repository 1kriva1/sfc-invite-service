using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Exist;

public class GamePlayerInviteExistQuery : Request<GamePlayerInviteExistViewModel>
{
    public override RequestId RequestId { get => RequestId.ExistGamePlayerInvite; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public InviteStatusEnum? Status { get; set; }

    public GamePlayerInviteExistQuery SetPlayerId(long playerId)
    {
        this.PlayerId = playerId;
        return this;
    }

    public GamePlayerInviteExistQuery SetGameId(long gameId)
    {
        this.GameId = gameId;
        return this;
    }
}