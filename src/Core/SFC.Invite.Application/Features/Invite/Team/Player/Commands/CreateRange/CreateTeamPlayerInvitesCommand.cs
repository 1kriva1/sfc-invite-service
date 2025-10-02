using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.CreateRange;
public class CreateTeamPlayerInvitesCommand : Request<CreateTeamPlayerInvitesViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayerInvites; }

    public required IEnumerable<CreateTeamPlayerInvitesDto> Invites { get; set; }

    public CreateTeamPlayerInvitesCommand SetTeamId(long teamId)
    {
        foreach (CreateTeamPlayerInvitesDto invite in Invites)
        {
            invite.TeamId = teamId;
        }

        return this;
    }
}