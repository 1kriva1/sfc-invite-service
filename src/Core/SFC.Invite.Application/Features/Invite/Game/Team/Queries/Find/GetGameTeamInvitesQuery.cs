using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find;
public class GetGameTeamInvitesQuery : BasePaginationRequest<GetGameTeamInvitesViewModel, GetGameTeamInvitesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGameTeamInvites; }

    public GetGameTeamInvitesQuery SetGameId(long gameId)
    {
        Filter = Filter ?? new GetGameTeamInvitesFilterDto();

        Filter.GameId = gameId;

        return this;
    }
}