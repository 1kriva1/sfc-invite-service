using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Create;

/// <summary>
/// **Create** Game player invite request.
/// </summary>
public class CreateGamePlayerInviteRequest : IMapTo<CreateGamePlayerInviteCommand>
{
    /// <summary>
    /// Game player invite model.
    /// </summary>
    public required CreateGamePlayerInviteModel Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateGamePlayerInviteRequest, CreateGamePlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}