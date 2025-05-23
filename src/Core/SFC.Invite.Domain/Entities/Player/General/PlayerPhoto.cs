using SFC.Invite.Domain.Enums.Data;

namespace SFC.Invite.Domain.Entities.Player.General;
public class PlayerPhoto : BasePlayerEntity
{
#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Source { get; set; } = [];
#pragma warning restore CA1819 // Properties should not return arrays

    public string Name { get; set; } = string.Empty;

    public required PhotoExtensionEnum Extension { get; set; }

    public int Size { get; set; }
}
