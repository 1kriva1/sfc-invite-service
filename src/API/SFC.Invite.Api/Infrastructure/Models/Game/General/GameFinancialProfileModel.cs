using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game's **financial** profile model.
/// </summary>
public class GameFinancialProfileModel : IMapFromReverse<GameFinancialProfileDto>
{
    /// <summary>
    /// Game play only on free field and without any extra expansions.
    /// </summary>
    public bool FreeGame { get; set; }

    /// <summary>
    /// How many need to pay for game.
    /// </summary>
    public decimal? PayAmount { get; set; }
}