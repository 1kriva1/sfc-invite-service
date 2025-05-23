using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
public class CreateTeamPlayerInviteDto : IMapTo<TeamPlayerInvite>
{
    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public string TeamComment { get; set; } = default!;
}