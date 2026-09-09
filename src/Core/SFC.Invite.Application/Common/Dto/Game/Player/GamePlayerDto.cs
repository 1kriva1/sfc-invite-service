using SFC.Invite.Application.Common.Dto.Common;
using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Game.Player;

namespace SFC.Invite.Application.Common.Dto.Game.Player;
public class GamePlayerDto : AuditableDto, IMapFromReverse<GamePlayer>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public required PlayerDto Player { get; set; }
}