using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Find;

/// <summary>
/// **Get** Game player invites response.
/// </summary>
public class GetGamePlayerInvitesResponse : BaseListResponse<GamePlayerInviteModel>, IMapFrom<GetGamePlayerInvitesViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGamePlayerInvitesViewModel, GetGamePlayerInvitesResponse>()
                                                   .IgnoreAllNonExisting();
}