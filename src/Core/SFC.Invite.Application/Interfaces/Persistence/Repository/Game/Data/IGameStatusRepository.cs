using SFC.Invite.Domain.Entities.Game.Data;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Data;
public interface IGameStatusRepository : IGameDataRepository<GameStatus, GameStatusEnum> { }