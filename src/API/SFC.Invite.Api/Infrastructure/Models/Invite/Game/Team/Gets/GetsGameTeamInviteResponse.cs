using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Gets;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Gets;

/// <summary>
/// **Get** all Game Team invites response.
/// </summary>
public class GetsGameTeamInviteResponse :
    BaseErrorResponse, IMapFrom<GetsGameTeamInviteViewModel>
{
    /// <summary>
    /// Game Team invite models.
    /// </summary>
    public IEnumerable<GameTeamInviteModel> Invites { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetsGameTeamInviteViewModel, GetsGameTeamInviteResponse>()
                                                   .IgnoreAllNonExisting();
}