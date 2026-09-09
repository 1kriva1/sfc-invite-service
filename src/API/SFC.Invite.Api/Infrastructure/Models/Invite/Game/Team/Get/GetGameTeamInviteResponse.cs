using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** Game Team invite response.
/// </summary>
public class GetGameTeamInviteResponse :
    BaseErrorResponse, IMapFrom<GetGameTeamInviteViewModel>
{
    /// <summary>
    /// Game Team invite model.
    /// </summary>
    public GameTeamInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamInviteViewModel, GetGameTeamInviteResponse>()
                                                   .IgnoreAllNonExisting();
}