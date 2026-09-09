using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Entities.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Domain.Entities.Game.General;

/// <summary>
/// Core entity of the service.
/// </summary>
public class Game : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public GameStatusEnum StatusId { get; set; }

    public required GameGeneralProfile GeneralProfile { get; set; }

    public required GameFinancialProfile FinancialProfile { get; set; }

    public required GameInventaryProfile InventaryProfile { get; set; }

    public required GameAvailability Availability { get; set; }

    public ICollection<GameTag> Tags { get; } = [];

    public ICollection<GamePlayer> Players { get; } = [];

    public ICollection<GamePlayerInvite> PlayerInvites { get; } = [];

    public ICollection<GameTeamInvite> TeamInvites { get; } = [];
}