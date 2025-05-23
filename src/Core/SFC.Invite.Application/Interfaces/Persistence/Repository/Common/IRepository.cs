using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Interfaces.Persistence.Context;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Common;
public interface IRepository<T, TR, TID>
    where T : class
    where TR : IDbContext
{
    Task<T?> GetByIdAsync(TID id);

    Task<IReadOnlyList<T>> ListAllAsync();

    Task<PagedList<T>> FindAsync(FindParameters<T> parameters);

    Task<T> AddAsync(T entity);

    Task<T[]> AddRangeAsync(params T[] entities);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}