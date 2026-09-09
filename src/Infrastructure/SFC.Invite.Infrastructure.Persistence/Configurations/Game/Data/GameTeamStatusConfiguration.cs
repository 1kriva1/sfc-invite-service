using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.Data;
public class GameTeamStatusConfiguration : EnumDataEntityConfiguration<GameTeamStatus, GameTeamStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GameTeamStatus> builder)
    {
        builder.ToTable("TeamStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}