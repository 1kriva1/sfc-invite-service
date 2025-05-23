using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeam; }

    public TeamDto Team { get; set; } = null!;
}