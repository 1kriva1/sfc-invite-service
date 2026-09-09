using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Game.Data;
using SFC.Invite.Domain.Entities.Game.Team;
using SFC.Invite.Domain.Entities.Identity.General;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Game.Team;
public class GameTeamConfiguration : AuditableReferenceEntityConfiguration<GameTeam, long>
{
    public override void Configure(EntityTypeBuilder<GameTeam> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasIndex(t => new { t.GameId, t.TeamId })
               .IsUnique();

        builder.HasOne<GameTeamStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<GameTeamIndex>()
               .WithMany()
               .HasForeignKey(t => t.Index)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(t => t.Team)
               .WithMany()
               .HasForeignKey(t => t.TeamId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Teams", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}