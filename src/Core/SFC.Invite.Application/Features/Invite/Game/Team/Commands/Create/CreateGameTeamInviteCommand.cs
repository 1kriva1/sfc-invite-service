using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;
public class CreateGameTeamInviteCommand : Request<CreateGameTeamInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamInvite; }

    public required CreateGameTeamInviteDto Invite { get; set; }

    public CreateGameTeamInviteCommand SetTeamId(long teamId)
    {
        this.Invite.TeamId = teamId;
        return this;
    }

    public CreateGameTeamInviteCommand SetGameId(long gameId)
    {
        this.Invite.GameId = gameId;
        return this;
    }
}