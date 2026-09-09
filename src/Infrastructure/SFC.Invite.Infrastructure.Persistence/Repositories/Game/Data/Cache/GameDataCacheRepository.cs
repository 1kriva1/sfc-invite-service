using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Constants;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameDataCacheRepository<TEntity, TEnum>(GameDataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : DataRelatedCacheRepository<TEntity, GameDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }