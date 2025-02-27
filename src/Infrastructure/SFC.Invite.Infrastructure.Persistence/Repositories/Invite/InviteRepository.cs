using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite;
public class InviteRepository(InviteDbContext context)
    : Repository<InviteEntity, InviteDbContext, long>(context), IInviteRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.Invites.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Invites.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    #endregion Public

    #region Ovveride

    #endregion Ovveride
}
