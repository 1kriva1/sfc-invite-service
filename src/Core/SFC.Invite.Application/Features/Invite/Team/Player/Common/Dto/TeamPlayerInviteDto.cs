using SFC.Invite.Application.Common.Dto.Common;
using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Common.Dto;
public class TeamPlayerInviteDto : AuditableDto, IMapFrom<TeamPlayerInvite>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public int StatusId { get; set; }

    public required string TeamComment { get; set; }

    public string? PlayerComment { get; set; }

    public required PlayerDto Player { get; set; }
}