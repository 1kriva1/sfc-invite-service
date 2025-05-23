using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Data.Common;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Data.GetAll;

/// <summary>
/// Contain all available invite **data types**.
/// </summary>
public class GetAllInviteDataResponse : BaseErrorResponse, IMapFrom<GetAllInviteDataViewModel>
{
    /// <summary>
    /// Invite statuses.
    /// </summary>
    public IEnumerable<DataValueModel> InviteStatuses { get; init; } = [];
}