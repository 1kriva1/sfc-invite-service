using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Update.General;

/// <summary>
/// **Update** Game player invite model.
/// </summary>
public class UpdateGamePlayerInviteModel : IMapTo<UpdateGamePlayerInviteDto>
{
    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGamePlayerInviteModel, UpdateGamePlayerInviteDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}