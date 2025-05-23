using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Team.General.Commands.CreateRange;
public class CreateTeamsCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeams; }

    public IEnumerable<TeamDto> Teams { get; set; } = null!;
}