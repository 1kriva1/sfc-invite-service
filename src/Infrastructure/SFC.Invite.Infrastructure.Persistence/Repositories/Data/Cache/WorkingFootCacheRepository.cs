using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class WorkingFootCacheRepository(WorkingFootRepository repository, ICache cache)
    : DataCacheRepository<WorkingFoot, WorkingFootEnum>(repository, cache), IWorkingFootRepository
{ }
