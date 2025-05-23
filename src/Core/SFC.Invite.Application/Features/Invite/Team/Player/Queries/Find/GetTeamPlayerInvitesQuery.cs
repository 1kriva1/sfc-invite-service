using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
public class GetTeamPlayerInvitesQuery : BasePaginationRequest<GetTeamPlayerInvitesViewModel, GetTeamPlayerInvitesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayerInvites; }
}