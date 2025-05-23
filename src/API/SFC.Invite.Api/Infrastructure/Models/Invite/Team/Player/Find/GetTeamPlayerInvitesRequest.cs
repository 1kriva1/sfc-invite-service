using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Find.Filters;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Find;

/// <summary>
/// **Get** team player invites request.
/// </summary>
public class GetTeamPlayerInvitesRequest : BasePaginationRequest<GetTeamPlayerInvitesFilterModel>, IMapTo<GetTeamPlayerInvitesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayerInvitesRequest, GetTeamPlayerInvitesQuery>()
                                                   .IgnoreAllNonExisting();
}