using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Game.General;

namespace SFC.Invite.Application.Common.Dto.Game.General;
public class GameFinancialProfileDto : IMapFromReverse<GameFinancialProfile>
{
    public bool FreeGame { get; set; }

    public decimal? PayAmount { get; set; }
}