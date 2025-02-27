using SFC.Invite.Application.Features.Common.Dto.Common;

namespace SFC.Invite.Application.Common.Dto.Player.Filters;
public class PlayerAvailabilityLimitFilterDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}
