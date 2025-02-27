﻿using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatTypeCacheRepository(StatTypeRepository repository, ICache cache)
    : DataCacheRepository<StatType, StatTypeEnum>(repository, cache), IStatTypeRepository
{
#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private readonly IStatTypeRepository _repository = repository;
#pragma warning restore CA1859 // Use concrete types when possible for improved performance

    public Task<int> CountAsync()
    {
        return !Cache.TryGet(CacheKey, out IReadOnlyList<StatType> entities)
            ? _repository.CountAsync()
            : Task.FromResult(entities.Count);
    }
}
