using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameTeamStatusCacheRepository(GameTeamStatusRepository repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : GameDataCacheRepository<GameTeamStatus, GameTeamStatusEnum>(repository, cache), IGameTeamStatusRepository
{ }