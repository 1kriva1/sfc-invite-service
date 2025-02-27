using System.Linq.Expressions;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Application.Features.Common.Extensions;

namespace SFC.Invite.Application.Features.Invite.Queries.Find.Extensions;
public static class GetInvitesSortingExtensions
{
    public static IEnumerable<Sorting<InviteEntity, dynamic>> BuildInviteSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<InviteEntity>(BuildExpression);

    private static Expression<Func<InviteEntity, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            _ => null
        };
    }
}
