using SFC.Invite.Messages.Models.Data;

namespace SFC.Invite.Messages.Events.Invite.Data;
public record DataInitialized
{
    public IEnumerable<DataValue> InviteStatuses { get; init; } = [];
}