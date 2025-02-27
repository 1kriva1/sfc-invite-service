using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data;
public class DataRepository<T, TEnum>(DataDbContext context) : Repository<T, DataDbContext, TEnum>(context), IDataRepository<T, TEnum>
     where T : EnumDataEntity<TEnum>
     where TEnum : struct
{
    public virtual Task<bool> AnyAsync(TEnum id)
    {
        return Context.Set<T>().AnyAsync(u => u.Id.Equals(id));
    }

    public Task<T[]> ResetAsync(IEnumerable<T> entities)
    {
        Context.Clear<T>();

        return AddRangeAsync(entities.ToArray());
    }
}
