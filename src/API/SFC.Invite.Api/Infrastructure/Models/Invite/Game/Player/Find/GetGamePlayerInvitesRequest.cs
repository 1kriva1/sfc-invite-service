using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Find.Filters;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Find;

/// <summary>
/// **Get** Game player invites request.
/// </summary>
public class GetGamePlayerInvitesRequest : BasePaginationRequest<GetGamePlayerInvitesFilterModel>, IMapTo<GetGamePlayerInvitesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGamePlayerInvitesRequest, GetGamePlayerInvitesQuery>()
                                                   .IgnoreAllNonExisting();
}