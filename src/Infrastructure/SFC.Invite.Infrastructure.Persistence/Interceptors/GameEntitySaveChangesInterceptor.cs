using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Reference;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Infrastructure.Persistence.Extensions;

namespace SFC.Invite.Infrastructure.Persistence.Interceptors;
public class GameEntitySaveChangesInterceptor(IGameReference gameReference) : SaveChangesInterceptor
{
    private readonly IGameReference _gameReference = gameReference;

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

        IEnumerable<EntityEntry<IGameEntity>> entries = context.ChangeTracker.Entries<IGameEntity>();

        foreach (EntityEntry<IGameEntity> entry in entries)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                if (entry.Entity.Game is null)
                {
                    Task<GameEntity> game = GetGameAsync(entry.Entity.GameId, cancellationToken);
                    entry.SetReference(context, game.Result);
                }
            }
        }
    }

    private async Task<GameEntity> GetGameAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _gameReference.GetAsync(id, cancellationToken).ConfigureAwait(true)
                    ?? throw new NotFoundException(Localization.GameNotFound);
    }
}