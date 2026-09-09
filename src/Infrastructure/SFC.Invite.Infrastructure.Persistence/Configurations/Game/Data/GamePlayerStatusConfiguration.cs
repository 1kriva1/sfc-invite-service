using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.Data;
public class GamePlayerStatusConfiguration : EnumDataEntityConfiguration<GamePlayerStatus, GamePlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GamePlayerStatus> builder)
    {
        builder.ToTable("GamePlayerStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}