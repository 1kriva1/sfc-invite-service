using System.Linq.Expressions;

using SFC.Invite.Application.Common.Dto.Player.General.Filters;
using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Application.Features.Common.Extensions;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Player.General;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Extensions;
public static class GetGamePlayerInvitesSortingExtensions
{
    public static IEnumerable<Sorting<GamePlayerInvite, dynamic>> BuildGamePlayerInviteSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<GamePlayerInvite>(BuildGameSortingExpression);

    private static Expression<Func<GamePlayerInvite, dynamic>>? BuildGameSortingExpression(string name)
    {
        return name switch
        {
            $"{nameof(GetGamePlayerInvitesFilterDto.Invite)}.{nameof(GetGamePlayerInvitesInviteFilterDto.Statuses)}" => p => p.StatusId,
            $"{nameof(GetGamePlayerInvitesFilterDto.Player)}.{nameof(PlayerGeneralProfile.FirstName)}" => p => p.Player.GeneralProfile.FirstName,
            $"{nameof(GetGamePlayerInvitesFilterDto.Player)}.{nameof(PlayerGeneralProfile.LastName)}" => p => p.Player.GeneralProfile.LastName,
            $"{nameof(GetGamePlayerInvitesFilterDto.Player)}.{nameof(PlayerFootballProfile.PhysicalCondition)}" => p => p.Player.FootballProfile.PhysicalCondition!,
            $"{nameof(GetGamePlayerInvitesFilterDto.Player)}.{nameof(PlayerFootballProfile.Height)}" => p => p.Player.FootballProfile.Height!,
            $"{nameof(GetGamePlayerInvitesFilterDto.Player)}.{nameof(PlayerFootballProfile.Weight)}" => p => p.Player.FootballProfile.Weight!,
            $"{nameof(GetGamePlayerInvitesFilterDto.Player)}.{nameof(PlayerStatsFilterDto.Raiting)}" => p => p.Player.Stats.Sum(m => m.Value),
            _ => null
        };
    }
}