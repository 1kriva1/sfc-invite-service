using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Domain.Entities.Game.General;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.General;
public class GameTagConfiguration : IEntityTypeConfiguration<GameTag>
{
    public void Configure(EntityTypeBuilder<GameTag> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Value)
            .HasMaxLength(ValidationConstants.TagValueMaxLength)
            .IsRequired(true);

        builder.ToTable("Tags", DatabaseConstants.GameSchemaName);
    }
}