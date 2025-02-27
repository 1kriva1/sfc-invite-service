using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatSkillCacheRepository(StatSkillRepository repository, ICache cache)
    : DataCacheRepository<StatSkill, StatSkillEnum>(repository, cache), IStatSkillRepository
{ }
