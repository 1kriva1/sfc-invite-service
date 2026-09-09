using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.Data;
public class GameTeamIndexConfiguration : EnumDataEntityConfiguration<GameTeamIndex, GameTeamIndexEnum>
{
    public override void Configure(EntityTypeBuilder<GameTeamIndex> builder)
    {
        builder.ToTable("TeamIndexes", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}