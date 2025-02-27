using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class GameStyleCacheRepository(GameStyleRepository repository, ICache cache)
    : DataCacheRepository<GameStyle, GameStyleEnum>(repository, cache), IGameStyleRepository
{ }
