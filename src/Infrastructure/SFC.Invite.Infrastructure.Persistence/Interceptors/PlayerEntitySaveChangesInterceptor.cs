using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SFC.Invite.Application.Interfaces.Reference;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Interceptors;
public class PlayerEntitySaveChangesInterceptor(IPlayerReference playerReference) : SaveChangesInterceptor
{
    private readonly IPlayerReference _playerReference = playerReference;

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

        IEnumerable<EntityEntry<IPlayerEntity>> entries = context.ChangeTracker.Entries<IPlayerEntity>();

        foreach (EntityEntry<IPlayerEntity> entry in entries)
        {
            if (entry.Entity.Player is null)
            {
                Task<PlayerEntity> player = GetPlayer(entry.Entity.PlayerId, cancellationToken);

                // just to check if player exist
                entry.Entity.Player = player.Result;
                context.Entry<PlayerEntity>(entry.Entity.Player).State = EntityState.Unchanged;
            }
        }
    }

    private async Task<PlayerEntity> GetPlayer(long id, CancellationToken cancellationToken = default)
    {
        return await _playerReference.GetAsync(id, cancellationToken).ConfigureAwait(true)
                    ?? throw new NotFoundException(Localization.PlayerNotFound);
    }
}
