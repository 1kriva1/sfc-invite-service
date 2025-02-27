using AutoMapper;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Invites.Find.Filters;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Queries.Find;
using SFC.Invite.Api.Infrastructure.Models.Base;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Find;

/// <summary>
/// **Get** invitemultiple request.
/// </summary>
public class GetInvitesRequest : BasePaginationRequest<GetInvitesFilterModel>, IMapTo<GetInvitesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetInvitesRequest, GetInvitesQuery>()
                                                   .IgnoreAllNonExisting();
}
