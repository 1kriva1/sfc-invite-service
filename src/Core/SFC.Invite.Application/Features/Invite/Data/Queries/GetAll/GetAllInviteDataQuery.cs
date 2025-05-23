using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;

public class GetAllInviteDataQuery : Request<GetAllInviteDataViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllInviteData; }
}