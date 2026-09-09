using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game **profile** model.
/// </summary>
public class GameProfileModel : IMapFromReverse<GameProfileDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public required GameGeneralProfileModel General { get; set; }

    /// <summary>
    /// Financial profile.
    /// </summary>
    public required GameFinancialProfileModel Financial { get; set; }

    /// <summary>
    /// Inventary profile.
    /// </summary>
    public required GameInventaryProfileModel Inventary { get; set; }
}