using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Data;
public class FootballPositionConfiguration : EnumDataEntityConfiguration<FootballPosition, FootballPositionEnum>
{
    public override void Configure(EntityTypeBuilder<FootballPosition> builder)
    {
        builder.ToTable("FootballPositions", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}
