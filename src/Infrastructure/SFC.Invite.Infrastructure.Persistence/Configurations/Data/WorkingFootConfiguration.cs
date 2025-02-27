using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Data;
public class WorkingFootConfiguration : EnumDataEntityConfiguration<WorkingFoot, WorkingFootEnum>
{
    public override void Configure(EntityTypeBuilder<WorkingFoot> builder)
    {
        builder.ToTable("WorkingFoots", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}
