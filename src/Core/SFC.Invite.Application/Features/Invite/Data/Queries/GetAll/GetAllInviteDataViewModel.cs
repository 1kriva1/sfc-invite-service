using SFC.Invite.Application.Features.Invite.Data.Queries.Common.Dto;

namespace SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;

public record GetAllInviteDataViewModel
{
    public IEnumerable<DataValueDto> InviteStatuses { get; init; } = [];
}