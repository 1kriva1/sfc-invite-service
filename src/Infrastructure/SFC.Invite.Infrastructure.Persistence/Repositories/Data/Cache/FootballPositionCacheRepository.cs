using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class FootballPositionCacheRepository(FootballPositionRepository repository, ICache cache)
    : DataCacheRepository<FootballPosition, FootballPositionEnum>(repository, cache), IFootballPositionRepository
{ }
