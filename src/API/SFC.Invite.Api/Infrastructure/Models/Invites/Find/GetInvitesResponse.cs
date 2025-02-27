using AutoMapper;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invites.Common;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Queries.Find;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Find;

/// <summary>
/// **Get** invitemultiple response.
/// </summary>
public class GetInvitesResponse : BaseListResponse<InviteModel>, IMapFrom<GetInvitesViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetInvitesViewModel, GetInvitesResponse>()
                                                   .IgnoreAllNonExisting();
}
