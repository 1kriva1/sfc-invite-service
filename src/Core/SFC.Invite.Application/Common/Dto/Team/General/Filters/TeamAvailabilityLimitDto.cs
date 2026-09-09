using SFC.Invite.Application.Features.Common.Dto.Common;

namespace SFC.Invite.Application.Common.Dto.Team.General.Filters;
public class TeamAvailabilityLimitDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}