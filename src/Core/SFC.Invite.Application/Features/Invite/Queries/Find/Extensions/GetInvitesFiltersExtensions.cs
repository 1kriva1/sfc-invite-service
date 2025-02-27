using SFC.Invite.Application.Features.Common.Models.Find.Filters;
using SFC.Invite.Application.Features.Invite.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Queries.Find.Extensions;
public static class GetInvitesFiltersExtensions
{
    public static IEnumerable<Filter<InviteEntity>> BuildSearchFilters(this GetInvitesFilterDto filter)
    {
        return [];
    }
}
