using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Domain.Entities.Team.General;
public class Team : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public required TeamGeneralProfile GeneralProfile { get; set; }

    public required TeamFinancialProfile FinancialProfile { get; set; }

    public TeamLogo? Logo { get; set; }

    public ICollection<TeamAvailability> Availability { get; } = [];

    public ICollection<TeamTag> Tags { get; } = [];

    public ICollection<TeamShirt> Shirts { get; } = [];

    public ICollection<TeamPlayer> Players { get; } = [];

    public ICollection<TeamPlayerInvite> PlayerInvites { get; } = [];
}