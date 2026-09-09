using System.Linq.Expressions;

using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Application.Features.Common.Extensions;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Team.General;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Extensions;
public static class GetGameTeamInvitesSortingExtensions
{
    public static IEnumerable<Sorting<GameTeamInvite, dynamic>> BuildGameTeamInviteSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<GameTeamInvite>(BuildGameTeamInvitesSortingExpression);

    private static Expression<Func<GameTeamInvite, dynamic>>? BuildGameTeamInvitesSortingExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetGameTeamInvitesFilterDto.Invite)}.{nameof(GetGameTeamInvitesInviteFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetGameTeamInvitesFilterDto.Team)}.{nameof(TeamGeneralProfile.Name)}" => p => p.Team.GeneralProfile.Name,
            $"{nameof(GetGameTeamInvitesFilterDto.Team)}.{nameof(TeamGeneralProfile.City)}" => p => p.Team.GeneralProfile.City,
            _ => null
        };
    }
}