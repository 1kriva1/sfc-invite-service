using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository;

namespace SFC.Invite.Infrastructure.Persistence.Repositories;
public class CacheRepository<T, TR, TID>(Repository<T, TR, TID> repository, ICache cache)
    : IRepository<T, TR, TID>
    where T : class
    where TR : DbContext, IDbContext
{
    private readonly Repository<T, TR, TID> _repository = repository;

    protected ICache Cache { get; } = cache;

    protected virtual string CacheKey { get => $"{typeof(T).Name}"; }

    public virtual async Task<IReadOnlyList<T>> ListAllAsync()
    {
        if (!Cache.TryGet(CacheKey, out IReadOnlyList<T> list))
        {
            list = await _repository.ListAllAsync()
                                    .ConfigureAwait(false);

            await Cache.SetAsync<IReadOnlyList<T>>(CacheKey, list)
                        .ConfigureAwait(false);
        }

        return list;
    }

    public Task<T?> GetByIdAsync(TID id) => _repository.GetByIdAsync(id);

    public Task<T> AddAsync(T entity) => _repository.AddAsync(entity);

    public Task DeleteAsync(T entity) => _repository.DeleteAsync(entity);

    public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);

    public Task<PagedList<T>> FindAsync(FindParameters<T> parameters) => _repository.FindAsync(parameters);

    public Task<T[]> AddRangeAsync(params T[] entities) => _repository.AddRangeAsync(entities);
}
