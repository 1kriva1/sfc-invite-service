using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class DataCacheRepository<T, TEnum>(DataRepository<T, TEnum> repository, ICache cache)
    : CacheRepository<T, DataDbContext, TEnum>(repository, cache)
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
    private readonly DataRepository<T, TEnum> _repository = repository;

    public Task<bool> AnyAsync(TEnum id)
    {
        return Cache.TryGet(CacheKey, out IReadOnlyList<T> list)
        ? Task.FromResult(list.Any(u => u.Id.Equals(id)))
            : _repository.AnyAsync(id);
    }

    public Task<T[]> ResetAsync(IEnumerable<T> entities) => _repository.ResetAsync(entities);
}
