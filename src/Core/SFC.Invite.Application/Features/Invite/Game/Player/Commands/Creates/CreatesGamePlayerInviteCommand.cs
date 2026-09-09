using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;
public class CreatesGamePlayerInviteCommand : Request<CreatesGamePlayerInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayerInvites; }

    public required IEnumerable<CreatesGamePlayerInviteDto> Invites { get; set; }

    public CreatesGamePlayerInviteCommand SetGameId(long GameId)
    {
        foreach (CreatesGamePlayerInviteDto invite in Invites)
        {
            invite.GameId = GameId;
        }

        return this;
    }
}