using SFC.Invite.Messages.Models.Common;

namespace SFC.Invite.Messages.Models.Invite.Team.Player;
public class TeamPlayerInvite : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public required string TeamComment { get; set; }

    public string? PlayerComment { get; set; }
}