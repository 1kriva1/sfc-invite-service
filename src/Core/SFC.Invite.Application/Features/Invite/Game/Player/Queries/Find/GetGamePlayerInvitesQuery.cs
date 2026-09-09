using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;
public class GetGamePlayerInvitesQuery : BasePaginationRequest<GetGamePlayerInvitesViewModel, GetGamePlayerInvitesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGamePlayerInvites; }

    public GetGamePlayerInvitesQuery SetGameId(long gameId)
    {
        Filter = Filter ?? new GetGamePlayerInvitesFilterDto();

        Filter.GameId = gameId;

        return this;
    }
}