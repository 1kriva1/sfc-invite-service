using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Team.Data.Common.Dto;

namespace SFC.Invite.Application.Features.Team.Data.Commands.Reset;
public class ResetTeamDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetTeamData; }

    public IEnumerable<TeamPlayerStatusDto> TeamPlayerStatuses { get; init; } = [];
}