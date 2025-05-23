using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
public class InviteDataCacheRepository<TEntity, TEnum>(InviteDataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, InviteDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }