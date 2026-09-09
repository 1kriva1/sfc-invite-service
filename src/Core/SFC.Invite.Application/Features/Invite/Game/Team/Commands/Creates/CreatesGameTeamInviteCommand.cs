using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;
public class CreatesGameTeamInviteCommand : Request<CreatesGameTeamInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamInvites; }

    public required IEnumerable<CreatesGameTeamInviteDto> Invites { get; set; }

    public CreatesGameTeamInviteCommand SetGameId(long gameId)
    {
        foreach (CreatesGameTeamInviteDto invite in Invites)
        {
            invite.GameId = gameId;
        }

        return this;
    }
}