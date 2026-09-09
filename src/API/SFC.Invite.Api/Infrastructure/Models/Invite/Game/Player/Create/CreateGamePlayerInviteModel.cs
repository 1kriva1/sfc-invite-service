using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Create;

/// <summary>
/// **Create** Game player invite model.
/// </summary>
public class CreateGamePlayerInviteModel : IMapTo<CreateGamePlayerInviteDto>
{
    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGamePlayerInviteModel, CreateGamePlayerInviteDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}