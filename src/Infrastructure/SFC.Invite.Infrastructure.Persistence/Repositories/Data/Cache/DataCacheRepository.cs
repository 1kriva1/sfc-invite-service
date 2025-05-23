using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class DataCacheRepository<TEntity, TEnum>(DataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, DataDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }