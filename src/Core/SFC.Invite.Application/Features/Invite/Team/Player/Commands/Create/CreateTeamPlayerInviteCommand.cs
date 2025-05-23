using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
public class CreateTeamPlayerInviteCommand : Request<CreateTeamPlayerInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayerInvite; }

    public required CreateTeamPlayerInviteDto Invite { get; set; }

    public CreateTeamPlayerInviteCommand SetPlayerId(long playerId)
    {
        this.Invite.PlayerId = playerId;
        return this;
    }

    public CreateTeamPlayerInviteCommand SetTeamId(long teamId)
    {
        this.Invite.TeamId = teamId;
        return this;
    }
}