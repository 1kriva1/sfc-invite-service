using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Game.General;

namespace SFC.Invite.Application.Common.Dto.Game.General;
public class GameInventaryProfileDto : IMapFromReverse<GameInventaryProfile>
{
    public bool ShirtsRequired { get; set; }

    public int? ShirtsCount { get; set; }
}