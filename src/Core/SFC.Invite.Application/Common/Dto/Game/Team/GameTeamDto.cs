using SFC.Invite.Application.Common.Dto.Common;
using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Game.Team;

namespace SFC.Invite.Application.Common.Dto.Game.Team;
public class GameTeamDto : AuditableDto, IMapFromReverse<GameTeam>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public int StatusId { get; set; }

    public int? Index { get; set; }

    public required TeamDto Team { get; set; }
}