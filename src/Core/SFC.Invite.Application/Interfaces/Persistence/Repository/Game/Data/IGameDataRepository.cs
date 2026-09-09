using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Invite.Domain.Common;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Data;

/// <summary>
/// Data related repository (Data service).
/// Enum based entities.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TEnum">Enum type.</typeparam>
public interface IGameDataRepository<TEntity, TEnum> : IDataRepository<TEntity, IGameDbContext, TEnum>
    where TEntity : EnumDataEntity<TEnum>
    where TEnum : struct
{ }