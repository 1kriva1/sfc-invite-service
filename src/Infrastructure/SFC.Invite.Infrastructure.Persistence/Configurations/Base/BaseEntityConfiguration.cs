using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SFC.Invite.Domain.Common;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Base;
public class BaseEntityConfiguration<TEntity, TID> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TID>
    where TID : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd()
               .HasColumnOrder(0)
               .IsRequired(true);
    }
}
