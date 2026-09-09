using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Gets;

public class GetsGameTeamInviteQuery : Request<GetsGameTeamInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.GetsGameTeamInvite; }

    public long GameId { get; set; }
}