using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Common.Dto.Pagination;

namespace SFC.Invite.Application.Features.Common.Models.Find.Paging;

/// <summary>
/// Pagination for quering to database.
/// </summary>
public class Pagination : IMapFrom<PaginationDto>
{
    public int Page { get; set; }

    public int Size { get; set; }
}
