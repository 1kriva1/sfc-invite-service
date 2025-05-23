using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data;
public class InviteDataRepository<TEntity, TEnum>(InviteDbContext context)
     : DataRepository<TEntity, InviteDbContext, TEnum>(context), IInviteDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }