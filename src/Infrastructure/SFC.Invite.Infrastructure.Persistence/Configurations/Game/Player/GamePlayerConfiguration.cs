using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Domain.Entities.Game.Player;
using SFC.Invite.Domain.Entities.Identity.General;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.Player;
public class GamePlayerConfiguration : AuditableReferenceEntityConfiguration<GamePlayer, long>
{
    public override void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<GamePlayerStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Players", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}