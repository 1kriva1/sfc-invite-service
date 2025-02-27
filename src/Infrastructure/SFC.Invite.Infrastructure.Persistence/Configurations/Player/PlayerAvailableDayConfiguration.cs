using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Player;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Player;
public class PlayerAvailableDayConfiguration : IEntityTypeConfiguration<PlayerAvailableDay>
{
    public void Configure(EntityTypeBuilder<PlayerAvailableDay> builder)
    {
        builder.Property(e => e.Day)
            .HasConversion<byte>()
            .IsRequired(true);

        builder.ToTable("AvailableDays", DatabaseConstants.PlayerSchemaName);
    }
}
