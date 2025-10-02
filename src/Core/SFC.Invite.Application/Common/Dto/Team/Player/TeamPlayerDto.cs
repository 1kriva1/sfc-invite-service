using SFC.Invite.Application.Common.Dto.Common;
using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Application.Common.Dto.Team.Player;
public class TeamPlayerDto : AuditableDto, IMapFromReverse<TeamPlayer>
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public Guid UserId { get; set; }

    public required PlayerDto Player { get; set; }
}