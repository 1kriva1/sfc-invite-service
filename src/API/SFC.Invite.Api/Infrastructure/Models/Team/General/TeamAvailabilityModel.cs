using SFC.Invite.Api.Infrastructure.Models.Common;
using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Team.General;

/// <summary>
/// Team's **availability** model (when team is available to play).
/// </summary>
public class TeamAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<TeamAvailabilityDto>
{
    /// <summary>
    /// Day of week.
    /// </summary>
    public DayOfWeek Day { get; set; }
}