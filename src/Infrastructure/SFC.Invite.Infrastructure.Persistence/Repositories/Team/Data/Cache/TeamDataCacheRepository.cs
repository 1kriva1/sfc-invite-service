using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Constants;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamDataCacheRepository<TEntity, TEnum>(TeamDataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Team)] ICache cache)
    : DataRelatedCacheRepository<TEntity, TeamDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }