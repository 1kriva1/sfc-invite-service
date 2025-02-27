using SFC.Invite.Application.Interfaces.Common;

namespace SFC.Invite.Infrastructure.Services.Common;
public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime DateNow => DateTime.UtcNow.Date;
}
