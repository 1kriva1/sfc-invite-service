using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Find.Filters;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Find;

/// <summary>
/// **Get** Game Team invites request.
/// </summary>
public class GetGameTeamInvitesRequest : BasePaginationRequest<GetGameTeamInvitesFilterModel>, IMapTo<GetGameTeamInvitesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamInvitesRequest, GetGameTeamInvitesQuery>()
                                                   .IgnoreAllNonExisting();
}