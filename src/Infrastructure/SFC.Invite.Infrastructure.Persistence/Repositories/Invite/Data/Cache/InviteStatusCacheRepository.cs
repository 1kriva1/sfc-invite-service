using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
public class InviteStatusCacheRepository(InviteStatusRepository repository, [FromKeyedServices(CacheInstance.Invite)] ICache cache)
    : InviteDataCacheRepository<InviteStatus, InviteStatusEnum>(repository, cache), IInviteStatusRepository
{ }