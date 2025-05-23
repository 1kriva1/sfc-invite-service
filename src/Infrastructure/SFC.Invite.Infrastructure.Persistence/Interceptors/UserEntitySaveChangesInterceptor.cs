using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Identity;
using SFC.Invite.Application.Interfaces.Reference;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Entities.Identity.General;

namespace SFC.Invite.Infrastructure.Persistence.Interceptors;
public class UserEntitySaveChangesInterceptor(IUserService userService, IIdentityReference identityReference) : SaveChangesInterceptor
{
    private readonly IUserService _userService = userService;
    private readonly IIdentityReference _identityReference = identityReference;

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context, cancellationToken);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context, CancellationToken cancellationToken = default)
    {
        if (context == null) return;

        IEnumerable<EntityEntry<IUserEntity>> entries = context.ChangeTracker.Entries<IUserEntity>();

        foreach (EntityEntry<IUserEntity> entry in entries)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                if (entry.Entity.UserId == Guid.Empty)
                {
                    Task<User> user = GetUser(cancellationToken);
                    entry.Entity.UserId = user.Result.Id;
                }

            }
        }
    }

    private async Task<User> GetUser(CancellationToken cancellationToken = default)
    {
        // get user id from context
        Guid userId = _userService.GetUserId()
            ?? throw new AuthorizationException(Localization.AuthorizationError);

        User user = await _identityReference.GetAsync(userId, cancellationToken).ConfigureAwait(true)
            ?? throw new AuthorizationException(Localization.AuthorizationError);

        return user;
    }
}