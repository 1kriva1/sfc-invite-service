using SFC.Invite.Application.Common.Dto.Game.General;

namespace SFC.Invite.Application.Interfaces.Game.General;
public interface IGameService
{
    Task<GameDto?> GetGameAsync(long id, CancellationToken cancellationToken = default);
}