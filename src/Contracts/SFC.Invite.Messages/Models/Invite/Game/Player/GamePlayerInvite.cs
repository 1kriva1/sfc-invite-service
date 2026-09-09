using SFC.Invite.Messages.Models.Common;

namespace SFC.Invite.Messages.Models.Invite.Game.Player;
public class GamePlayerInvite : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public required string GameComment { get; set; }

    public string? PlayerComment { get; set; }
}