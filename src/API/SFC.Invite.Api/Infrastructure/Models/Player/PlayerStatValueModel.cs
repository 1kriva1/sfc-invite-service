using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Player;

/// <summary>
/// Player stat value model.
/// </summary>
public class PlayerStatValueModel : IMapFromReverse<PlayerStatValueDto>
{
    /// <summary>
    /// Type of stat
    /// </summary>
    public int Type { get; set; } = default!;

    /// <summary>
    /// Stat value.
    /// </summary>
    public byte Value { get; set; }
}