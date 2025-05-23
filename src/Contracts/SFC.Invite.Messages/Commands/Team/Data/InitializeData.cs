using SFC.Invite.Messages.Models.Data;

namespace SFC.Invite.Messages.Commands.Team.Data;
public record InitializeData
{
    public IEnumerable<DataValue> TeamPlayerStatuses { get; init; } = [];
}