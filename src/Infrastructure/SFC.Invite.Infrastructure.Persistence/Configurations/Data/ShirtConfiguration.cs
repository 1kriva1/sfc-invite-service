using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Data;
public class ShirtConfiguration : EnumDataEntityConfiguration<Shirt, ShirtEnum>
{
    public override void Configure(EntityTypeBuilder<Shirt> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("Shirts", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}