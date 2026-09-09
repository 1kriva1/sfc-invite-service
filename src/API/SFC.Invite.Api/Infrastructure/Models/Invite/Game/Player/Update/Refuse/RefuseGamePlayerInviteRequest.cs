using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Update.Refuse;

/// <summary>
/// **Refuse** Game player invite request.
/// </summary>
public class RefuseGamePlayerInviteRequest : IMapTo<UpdateGamePlayerInviteCommand>
{
    /// <summary>
    /// Refuse Game player invite model.
    /// </summary>
    public RefuseGamePlayerInviteModel Invite { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RefuseGamePlayerInviteRequest, UpdateGamePlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}