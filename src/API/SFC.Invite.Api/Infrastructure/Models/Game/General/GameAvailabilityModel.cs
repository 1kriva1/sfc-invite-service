using SFC.Invite.Api.Infrastructure.Models.Common;
using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game's **availability** model (when game is available to play).
/// </summary>
public class GameAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<GameAvailabilityDto>
{
    /// <summary>
    /// Date.
    /// </summary>
    public DateOnly Date { get; set; }
}