namespace SFC.Invite.Application.Features.Common.Dto.Base;

/// <summary>
/// Base DTO class for auditable entities.
/// </summary>
public class BaseAuditableDto
{
    public DateTime CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public Guid LastModifiedBy { get; set; }
}
