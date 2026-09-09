using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.Data;
public class GameStatusConfiguration : EnumDataEntityConfiguration<GameStatus, GameStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GameStatus> builder)
    {
        builder.ToTable("GameStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}