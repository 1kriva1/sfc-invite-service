using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Player;
public class PlayerAvailableDay : BaseEntity<long>
{
    public PlayerAvailability Availability { get; set; } = null!;

    public DayOfWeek Day { get; set; }
}
