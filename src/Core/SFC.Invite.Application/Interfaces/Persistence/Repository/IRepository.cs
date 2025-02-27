using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository;

/// <summary>
/// Parent for all repositories of the service.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TContext">DB context type.</typeparam>
/// <typeparam name="TID">Entity identifier type.</typeparam>
public interface IRepository<TEntity, TContext, TID>
    where TEntity : class
    where TContext : IDbContext
{
    Task<TEntity?> GetByIdAsync(TID id);

    Task<IReadOnlyList<TEntity>> ListAllAsync();

    Task<PagedList<TEntity>> FindAsync(FindParameters<TEntity> parameters);

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity[]> AddRangeAsync(params TEntity[] entities);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}