using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Gets;

public class GetsGamePlayerInviteQuery : Request<GetsGamePlayerInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.GetsGamePlayerInvite; }

    public long GameId { get; set; }
}