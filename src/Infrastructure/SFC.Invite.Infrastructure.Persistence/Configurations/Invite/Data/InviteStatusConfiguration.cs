using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Invite.Data;
public class InviteStatusConfiguration : EnumDataEntityConfiguration<InviteStatus, InviteStatusEnum>
{
    public override void Configure(EntityTypeBuilder<InviteStatus> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("InviteStatuses", DatabaseConstants.DefaultSchemaName);
        base.Configure(builder);
    }
}