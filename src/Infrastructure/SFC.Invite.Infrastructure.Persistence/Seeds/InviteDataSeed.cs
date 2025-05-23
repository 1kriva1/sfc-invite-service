using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Infrastructure.Persistence.Extensions;

namespace SFC.Invite.Infrastructure.Persistence.Seeds;
public static class InviteDataSeed
{
    public static void SeedInviteData(this ModelBuilder builder, IDateTimeService dateTimeService)
    {
        builder.SeedDataEnumValues<InviteStatus, InviteStatusEnum>(@enum =>
            new InviteStatus(@enum).SetCreatedDate(dateTimeService));
    }
}