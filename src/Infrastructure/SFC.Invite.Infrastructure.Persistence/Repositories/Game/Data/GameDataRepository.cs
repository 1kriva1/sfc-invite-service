using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Game.Data;
public class GameDataRepository<TEntity, TEnum>(GameDbContext context)
    : DataRepository<TEntity, GameDbContext, TEnum>(context), IGameDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }