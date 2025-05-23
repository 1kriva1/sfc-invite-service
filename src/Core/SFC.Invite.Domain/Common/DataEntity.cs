using SFC.Invite.Domain.Common.Interfaces;

namespace SFC.Invite.Domain.Common;
public class DataEntity<TId> : BaseEntity<TId>, IDataEntity
{
    public DateTime CreatedDate { get; set; }
}