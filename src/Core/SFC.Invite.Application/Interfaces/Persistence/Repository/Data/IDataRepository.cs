using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Domain.Common;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Data;

/// <summary>
/// Data related repository (Data service).
/// Enum based entities.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TEnum">Enum type.</typeparam>
public interface IDataRepository<TEntity, TEnum> : IRepository<TEntity, IDataDbContext, TEnum>
    where TEntity : EnumDataEntity<TEnum>
    where TEnum : struct
{
    /// <summary>
    /// Check if data related entity exist in database.
    /// </summary>
    /// <param name="id">Entity identifier.</param>
    /// <returns>True if exist, othrwise false.</returns>
    Task<bool> AnyAsync(TEnum id);

    /// <summary>
    /// Reset all data related enteties.
    /// </summary>
    /// <param name="entities">Data related enteties.</param>
    /// <returns>Reseted data related enteties.</returns>
    Task<TEntity[]> ResetAsync(IEnumerable<TEntity> entities);
}
