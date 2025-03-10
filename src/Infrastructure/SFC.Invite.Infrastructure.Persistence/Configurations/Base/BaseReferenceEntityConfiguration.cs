﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Common;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Base;
public abstract class BaseReferenceEntityConfiguration<TEntity, TID> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TID>
    where TID : struct
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
               .ValueGeneratedNever()
               .HasColumnOrder(0)
               .IsRequired(true);
    }
}
