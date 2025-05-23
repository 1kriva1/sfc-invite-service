using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Invite.Domain.Entities.Invite.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
public class InviteStatusCacheRepository(InviteStatusRepository repository, ICache cache)
    : InviteDataCacheRepository<InviteStatus, InviteStatusEnum>(repository, cache), IInviteStatusRepository
{ }