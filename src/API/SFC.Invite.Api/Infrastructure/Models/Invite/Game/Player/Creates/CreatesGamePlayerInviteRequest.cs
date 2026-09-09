using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Creates;

/// <summary>
/// **Creates** Game player invites request.
/// </summary>
public class CreatesGamePlayerInviteRequest : IMapTo<CreatesGamePlayerInviteCommand>
{
    /// <summary>
    /// Game player invite model.
    /// </summary>
    public required IEnumerable<CreatesGamePlayerInviteModel> Invites { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGamePlayerInviteRequest, CreatesGamePlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}