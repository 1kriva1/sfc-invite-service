using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Update.General;

/// <summary>
/// **Update** Game player invite request.
/// </summary>
public class UpdateGamePlayerInviteRequest : IMapTo<UpdateGamePlayerInviteCommand>
{
    /// <summary>
    /// Update Game player invite model.
    /// </summary>
    public UpdateGamePlayerInviteModel Invite { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGamePlayerInviteRequest, UpdateGamePlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}