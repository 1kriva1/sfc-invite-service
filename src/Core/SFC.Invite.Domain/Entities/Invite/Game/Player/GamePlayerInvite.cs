using SFC.Invite.Domain.Common.Interfaces;

namespace SFC.Invite.Domain.Entities.Invite.Game.Player;
public class GamePlayerInvite : InviteEntity, IPlayerEntity, IGameEntity
{
    public long GameId { get; set; }

    public GameEntity Game { get; set; } = default!;

    public required string GameComment { get; set; }

    public long PlayerId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public string? PlayerComment { get; set; }
}