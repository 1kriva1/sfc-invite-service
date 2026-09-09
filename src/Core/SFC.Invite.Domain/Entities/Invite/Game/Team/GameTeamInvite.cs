using SFC.Invite.Domain.Common.Interfaces;

namespace SFC.Invite.Domain.Entities.Invite.Game.Team;
public class GameTeamInvite : InviteEntity, ITeamEntity, IGameEntity
{
    public long GameId { get; set; }

    public GameEntity Game { get; set; } = default!;

    public required string GameComment { get; set; }

    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = default!;

    public string? TeamComment { get; set; }
}