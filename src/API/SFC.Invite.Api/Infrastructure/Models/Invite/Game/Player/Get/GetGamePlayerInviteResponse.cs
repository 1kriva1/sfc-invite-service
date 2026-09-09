using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** Game player invite response.
/// </summary>
public class GetGamePlayerInviteResponse :
    BaseErrorResponse, IMapFrom<GetGamePlayerInviteViewModel>
{
    /// <summary>
    /// Game player invite model.
    /// </summary>
    public GamePlayerInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetGamePlayerInviteViewModel, GetGamePlayerInviteResponse>()
                                                   .IgnoreAllNonExisting();
}