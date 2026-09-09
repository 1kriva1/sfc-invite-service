using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Creates;

/// <summary>
/// **Creates** Game player invite model.
/// </summary>
public class CreatesGamePlayerInviteModel : IMapTo<CreatesGamePlayerInviteDto>
{
    /// <summary>
    /// Player for which Game send invite.
    /// </summary>
    public long Player { get; set; }

    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGamePlayerInviteModel, CreatesGamePlayerInviteDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment))
                                                   .ForMember(p => p.PlayerId, d => d.MapFrom(z => z.Player));
}