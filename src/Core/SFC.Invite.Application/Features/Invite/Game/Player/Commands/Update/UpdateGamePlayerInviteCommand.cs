using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;
public class UpdateGamePlayerInviteCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGamePlayerInvite; }

    public required UpdateGamePlayerInviteDto Invite { get; set; }

    public UpdateGamePlayerInviteCommand SetId(long id)
    {
        this.Invite.Id = id;
        return this;
    }

    public UpdateGamePlayerInviteCommand SetPlayerId(long playerId)
    {
        this.Invite.PlayerId = playerId;
        return this;
    }

    public UpdateGamePlayerInviteCommand SetGameId(long gameId)
    {
        this.Invite.GameId = gameId;
        return this;
    }

    public UpdateGamePlayerInviteCommand SetStatus(InviteStatusEnum status)
    {
        this.Invite.Status = (int)status;
        return this;
    }
}