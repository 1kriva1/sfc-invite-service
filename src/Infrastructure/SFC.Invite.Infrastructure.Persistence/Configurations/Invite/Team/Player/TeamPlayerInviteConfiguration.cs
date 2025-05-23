using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Domain.Entities.Identity.General;
using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Invite.Team.Player;
public class TeamPlayerInviteConfiguration : AuditableEntityConfiguration<TeamPlayerInvite, long>
{
    public override void Configure(EntityTypeBuilder<TeamPlayerInvite> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // it's for skip exception during update db (sql server only related)
        builder.HasOne(e => e.Team)
               .WithMany(e => e.PlayerInvites)
               .HasForeignKey(e => e.TeamId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // it's for skip exception during update db (sql server only related)
        builder.HasOne(e => e.Player)
               .WithMany(e => e.TeamInvites)
               .HasForeignKey(e => e.PlayerId)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne<InviteStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.Property(e => e.TeamComment)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(true);

        builder.Property(e => e.PlayerComment)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(false);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("TeamPlayerInvites");

        base.Configure(builder);
    }
}