using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Create;

/// <summary>
/// **Create** Game player invite response.
/// </summary>
public class CreateGamePlayerInviteResponse :
    BaseErrorResponse, IMapFrom<CreateGamePlayerInviteViewModel>
{
    /// <summary>
    /// Game player invite model.
    /// </summary>
    public GamePlayerInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGamePlayerInviteViewModel, CreateGamePlayerInviteResponse>()
                                                   .IgnoreAllNonExisting();
}