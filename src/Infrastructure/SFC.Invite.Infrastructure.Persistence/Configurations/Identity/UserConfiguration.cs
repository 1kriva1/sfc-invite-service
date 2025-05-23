using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Invite.Domain.Entities.Identity.General;
using SFC.Invite.Infrastructure.Persistence.Configurations.Base;
using SFC.Invite.Infrastructure.Persistence.Constants;

namespace SFC.Invite.Infrastructure.Persistence.Configurations.Identity;
public class UserConfiguration(bool isSqlServer) : AuditableReferenceEntityConfiguration<User, Guid>
{
    private readonly bool _isSqlServer = isSqlServer;

    public override void Configure(EntityTypeBuilder<User> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (_isSqlServer)
        {
            builder.ToTable("Users", DatabaseConstants.IdentitySchemaName);
        }
        else
        {
            builder.ToTable("Identity_Users");
        }

        base.Configure(builder);
    }
}