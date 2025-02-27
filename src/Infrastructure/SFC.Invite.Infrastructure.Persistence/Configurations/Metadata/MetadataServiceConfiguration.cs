using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Metadata;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Metadata;
public class MetadataServiceConfiguration : EnumEntityConfiguration<MetadataService, MetadataServiceEnum>
{
    public override void Configure(EntityTypeBuilder<MetadataService> builder)
    {
        builder.ToTable("Services", DatabaseConstants.MetadataSchemaName);
        base.Configure(builder);
    }
}
