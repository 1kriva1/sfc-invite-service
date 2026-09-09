using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Get;

public class GetGameTeamInviteQuery : Request<GetGameTeamInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGameTeamInvite; }

    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }
}