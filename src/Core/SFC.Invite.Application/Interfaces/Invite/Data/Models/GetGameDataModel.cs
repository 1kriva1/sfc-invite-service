using SFC.Invite.Domain.Entities.Invite.Data;

namespace SFC.Invite.Application.Interfaces.Invite.Data.Models;
public record GetGameDataModel
{
    public IEnumerable<InviteStatus> InviteStatuses { get; init; } = [];
}