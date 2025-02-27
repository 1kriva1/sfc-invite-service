using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Queries.Get;

public class GetInviteQuery : Request<GetInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.GetInvite; }

    public long InviteId { get; set; }
}
