using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Common.Dto.Pagination;

namespace SFC.Invite.Api.Infrastructure.Models.Pagination;

/// <summary>
/// **Pagination** model.
/// </summary>
public class PaginationModel : IMapTo<PaginationDto>
{
    /// <summary>
    /// Requested **page**.
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Requested page **size**.
    /// </summary>
    public int Size { get; set; }
}
