using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Data;
public class GameStyleConfiguration : EnumDataEntityConfiguration<GameStyle, GameStyleEnum>
{
    public override void Configure(EntityTypeBuilder<GameStyle> builder)
    {
        builder.ToTable("GameStyles", DatabaseConstants.DataSchemaName);
        base.Configure(builder);
    }
}
