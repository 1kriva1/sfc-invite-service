using SFC.Invite.Application.Common.Dto.Common;
using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Common.Dto;
public class GamePlayerInviteDto : AuditableDto, IMapFrom<GamePlayerInvite>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public required string GameComment { get; set; }

    public required GameDto Game { get; set; }

    public string? PlayerComment { get; set; }

    public required PlayerDto Player { get; set; }
}