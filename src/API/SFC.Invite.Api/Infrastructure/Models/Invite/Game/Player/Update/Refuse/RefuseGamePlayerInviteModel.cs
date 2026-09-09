using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Update.Refuse;

/// <summary>
/// **Refuse** Game player invite model.
/// </summary>
public class RefuseGamePlayerInviteModel : IMapTo<UpdateGamePlayerInviteDto>
{
    /// <summary>
    /// Comment from player to explain why he/she is refuse Game invite.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RefuseGamePlayerInviteModel, UpdateGamePlayerInviteDto>()
                                                   .ForMember(p => p.PlayerComment, d => d.MapFrom(z => z.Comment));
}