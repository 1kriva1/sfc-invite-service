using SFC.Invite.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Invite.Domain.Entities.Identity;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Extensions;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Identity;
public class UserRepository(IdentityDbContext context)
        : Repository<User, IdentityDbContext, Guid>(context), IUserRepository
{
    public async Task<User[]> AddRangeIfNotExistsAsync(params User[] users)
    {
        await Context.Set<User>().AddRangeIfNotExistsAsync<User, Guid>(users).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return users;
    }
}
