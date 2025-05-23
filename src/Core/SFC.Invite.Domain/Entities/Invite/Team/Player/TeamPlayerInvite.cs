using SFC.Invite.Domain.Common.Interfaces;

namespace SFC.Invite.Domain.Entities.Invite.Team.Player;
public class TeamPlayerInvite : InviteEntity, IPlayerEntity, ITeamEntity
{
    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = default!;

    public required string TeamComment { get; set; }

    public long PlayerId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public string? PlayerComment { get; set; }
}