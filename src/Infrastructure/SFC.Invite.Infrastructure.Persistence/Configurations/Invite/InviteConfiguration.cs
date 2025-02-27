using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Identity;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Invite;
public class InviteConfiguration : AuditableEntityConfiguration<InviteEntity, long>
{
    public override void Configure(EntityTypeBuilder<InviteEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("Invites");

        base.Configure(builder);
    }
}
