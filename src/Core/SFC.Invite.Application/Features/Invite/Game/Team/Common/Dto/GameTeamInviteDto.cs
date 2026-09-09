using SFC.Invite.Application.Common.Dto.Common;
using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Common.Dto;
public class GameTeamInviteDto : AuditableDto, IMapFrom<GameTeamInvite>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public required string GameComment { get; set; }

    public required GameDto Game { get; set; }

    public string? TeamComment { get; set; }

    public required TeamDto Team { get; set; }
}