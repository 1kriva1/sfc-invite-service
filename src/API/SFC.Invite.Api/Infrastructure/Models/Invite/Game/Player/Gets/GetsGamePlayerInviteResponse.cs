using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Gets;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Gets;

/// <summary>
/// **Get** all Game player invites response.
/// </summary>
public class GetsGamePlayerInviteResponse :
    BaseErrorResponse, IMapFrom<GetsGamePlayerInviteViewModel>
{
    /// <summary>
    /// Game player invite models.
    /// </summary>
    public IEnumerable<GamePlayerInviteModel> Invites { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetsGamePlayerInviteViewModel, GetsGamePlayerInviteResponse>()
                                                   .IgnoreAllNonExisting();
}