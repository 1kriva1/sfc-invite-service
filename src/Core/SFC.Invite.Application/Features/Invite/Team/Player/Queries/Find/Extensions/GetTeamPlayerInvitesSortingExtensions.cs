using System.Linq.Expressions;

using SFC.Invite.Application.Common.Dto.Player.Filters;
using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Application.Features.Common.Extensions;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Player.General;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Extensions;
public static class GetTeamPlayerInvitesSortingExtensions
{
    public static IEnumerable<Sorting<TeamPlayerInvite, dynamic>> BuildTeamPlayerInviteSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<TeamPlayerInvite>(BuildTeamSortingExpression);

    private static Expression<Func<TeamPlayerInvite, dynamic>>? BuildTeamSortingExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetTeamPlayerInvitesFilterDto.Invite)}.{nameof(GetTeamPlayerInvitesInviteFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetTeamPlayerInvitesFilterDto.Player)}.{nameof(PlayerGeneralProfile.FirstName)}" => p => p.Player.GeneralProfile.FirstName,
            $"{nameof(GetTeamPlayerInvitesFilterDto.Player)}.{nameof(PlayerGeneralProfile.LastName)}" => p => p.Player.GeneralProfile.LastName,
            $"{nameof(GetTeamPlayerInvitesFilterDto.Player)}.{nameof(PlayerFootballProfile.PhysicalCondition)}" => p => p.Player.FootballProfile.PhysicalCondition!,
            $"{nameof(GetTeamPlayerInvitesFilterDto.Player)}.{nameof(PlayerFootballProfile.Height)}" => p => p.Player.FootballProfile.Height!,
            $"{nameof(GetTeamPlayerInvitesFilterDto.Player)}.{nameof(PlayerFootballProfile.Weight)}" => p => p.Player.FootballProfile.Weight!,
            $"{nameof(GetTeamPlayerInvitesFilterDto.Player)}.{nameof(PlayerStatsFilterDto.Raiting)}" => p => p.Player.Stats.Sum(m => m.Value),
            _ => null
        };
    }
}