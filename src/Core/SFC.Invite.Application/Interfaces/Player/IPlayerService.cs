using SFC.Invite.Application.Common.Dto.Player.General;

namespace SFC.Invite.Application.Interfaces.Player;
public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerAsync(long id, CancellationToken cancellationToken = default);
}
