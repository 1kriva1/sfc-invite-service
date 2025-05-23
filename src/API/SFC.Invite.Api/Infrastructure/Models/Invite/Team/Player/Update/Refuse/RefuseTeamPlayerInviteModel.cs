using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Update.Refuse;

/// <summary>
/// **Refuse** team player invite model.
/// </summary>
public class RefuseTeamPlayerInviteModel : IMapTo<UpdateTeamPlayerInviteDto>
{
    /// <summary>
    /// Comment from player to explain why he/she is refuse team invite.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RefuseTeamPlayerInviteModel, UpdateTeamPlayerInviteDto>()
                                                   .ForMember(p => p.PlayerComment, d => d.MapFrom(z => z.Comment));
}