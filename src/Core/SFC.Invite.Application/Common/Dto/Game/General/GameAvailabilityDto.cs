using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Game.General;

namespace SFC.Invite.Application.Common.Dto.Game.General;
public class GameAvailabilityDto : IMapFromReverse<GameAvailability>
{
    public DateOnly Date { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}