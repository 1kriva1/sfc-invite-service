using SFC.Invite.Application.Features.Common.Dto.Base;
using SFC.Identity.Contracts.Headers;

namespace SFC.Invite.Infrastructure.Extensions;
public static class AuditableExtensions
{
    public static void SetAuditableProperties(this BaseAuditableDto value, AuditableHeader header)
    {
        value.CreatedDate = header.CreatedDate.ToDateTime();
        value.CreatedBy = Guid.Parse(header.CreatedBy);
        value.LastModifiedDate = header.LastModifiedDate.ToDateTime();
        value.LastModifiedBy = Guid.Parse(header.LastModifiedBy);
    }
}
