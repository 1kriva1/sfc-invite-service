using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Queries.Find;
public class GetInvitesQuery : BasePaginationRequest<GetInvitesViewModel, GetInvitesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetInvites; }
}
