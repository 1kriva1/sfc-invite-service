using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.GetAll;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
public class GetTeamPlayerInvitesQuery : BasePaginationRequest<GetTeamPlayerInvitesViewModel, GetTeamPlayerInvitesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayerInvites; }

    public GetTeamPlayerInvitesQuery SetTeamId(long teamId)
    {
        Filter = Filter ?? new GetTeamPlayerInvitesFilterDto();

        Filter.TeamId = teamId;

        return this;
    }
}