using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.GetAll;

public class GetAllTeamPlayerInvitesQuery : Request<GetAllTeamPlayerInvitesViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllTeamPlayerInvites; }

    public long TeamId { get; set; }
}