using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Domain.Entities.Player;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Player;
public class PlayerStatConfiguration : IEntityTypeConfiguration<PlayerStat>
{
    public void Configure(EntityTypeBuilder<PlayerStat> builder)
    {
        builder.HasOne<StatType>(e => e.Type)
              .WithMany()
              .HasForeignKey(t => t.TypeId)
              .IsRequired(true);

        builder.ToTable("Stats", DatabaseConstants.PlayerSchemaName);
    }
}
