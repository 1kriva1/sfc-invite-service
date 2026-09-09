using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.General;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.General;
public class GameFinancialProfileConfiguration : IEntityTypeConfiguration<GameFinancialProfile>
{
    public void Configure(EntityTypeBuilder<GameFinancialProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.FreeGame)
            .HasDefaultValue(false);

        builder.Property(e => e.PayAmount)
            .HasPrecision(18, 2);

        builder.ToTable("FinancialProfiles", DatabaseConstants.GameSchemaName);
    }
}