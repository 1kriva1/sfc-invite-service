using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Common.Interfaces;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Base;

public class AuditableEntityConfiguration<TEntity, TID> : BaseEntityConfiguration<TEntity, TID>
    where TEntity : BaseEntity<TID>, IAuditableEntity
    where TID : struct
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.CreatedDate)
            .IsRequired(true);

        builder.Property(e => e.CreatedBy)
            .IsRequired(true);

        builder.Property(e => e.LastModifiedDate)
            .IsRequired(true);

        builder.Property(e => e.LastModifiedBy)
            .IsRequired(true);

        base.Configure(builder);
    }
}