using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Invite.Domain.Common;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
public interface IInviteDataRepository<T, TEnum> : IDataRepository<T, IInviteDbContext, TEnum>
    where T : EnumDataEntity<TEnum>
    where TEnum : struct
{
}