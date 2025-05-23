﻿using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Common.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Domain.Entities.Player.General;
public class Player : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public PlayerGeneralProfile GeneralProfile { get; set; } = null!;

    public PlayerFootballProfile FootballProfile { get; set; } = null!;

    public PlayerAvailability Availability { get; set; } = null!;

    public PlayerStatPoints Points { get; set; } = null!;

    public PlayerPhoto Photo { get; set; } = null!;

    public ICollection<PlayerTag> Tags { get; } = [];

    public ICollection<PlayerStat> Stats { get; } = [];

    public ICollection<TeamPlayer> Teams { get; } = [];

    public ICollection<TeamPlayerInvite> TeamInvites { get; } = [];
}
