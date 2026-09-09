using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Game.Data;
public class GameTeamStatusRepository(GameDbContext context)
    : GameDataRepository<GameTeamStatus, GameTeamStatusEnum>(context), IGameTeamStatusRepository
{ }