using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
public interface IStatTypeRepository : IDataRepository<StatType, StatTypeEnum>
{
    Task<int> CountAsync();
}
