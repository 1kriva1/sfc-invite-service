using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;
public class CreateGamePlayerInviteCommand : Request<CreateGamePlayerInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayerInvite; }

    public required CreateGamePlayerInviteDto Invite { get; set; }

    public CreateGamePlayerInviteCommand SetPlayerId(long playerId)
    {
        this.Invite.PlayerId = playerId;
        return this;
    }

    public CreateGamePlayerInviteCommand SetGameId(long gameId)
    {
        this.Invite.GameId = gameId;
        return this;
    }
}