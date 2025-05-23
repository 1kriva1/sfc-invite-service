using SFC.Invite.Api.Infrastructure.Models.Common;
using SFC.Invite.Application.Common.Dto.Player.Filters;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Range limit by **stat skill**.
/// </summary>
public class PlayerStatsBySkillRangeLimitFilterModel :
    RangeLimitModel<short?>,
    IMapTo<PlayerStatsBySkillRangeLimitFilterDto>
{
    /// <summary>
    /// Stat skill unique identifier.
    /// </summary>
    public int Skill { get; set; }
}