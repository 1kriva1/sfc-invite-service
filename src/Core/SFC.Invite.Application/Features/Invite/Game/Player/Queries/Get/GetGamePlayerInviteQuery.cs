using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Get;

public class GetGamePlayerInviteQuery : Request<GetGamePlayerInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGamePlayerInvite; }

    public long Id { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }
}