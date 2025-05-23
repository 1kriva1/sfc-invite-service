using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;

public class GetTeamPlayerInviteQuery : Request<GetTeamPlayerInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.GetTeamPlayerInvite; }

    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }
}