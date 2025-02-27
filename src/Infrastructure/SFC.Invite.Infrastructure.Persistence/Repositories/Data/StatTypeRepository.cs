using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data;

public class StatTypeRepository(DataDbContext context)
    : DataRepository<StatType, StatTypeEnum>(context), IStatTypeRepository
{
    public virtual Task<int> CountAsync() => Context.StatTypes.CountAsync();

    public override async Task<IReadOnlyList<StatType>> ListAllAsync()
    {
        return await Context.StatTypes
                            .AsNoTracking()
                            .ToListAsync()
                            .ConfigureAwait(false);
    }
}
