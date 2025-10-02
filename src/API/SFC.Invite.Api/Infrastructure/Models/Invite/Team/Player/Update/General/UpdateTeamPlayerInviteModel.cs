using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Update.General;

/// <summary>
/// **Update** team player invite model.
/// </summary>
public class UpdateTeamPlayerInviteModel : IMapTo<UpdateTeamPlayerInviteDto>
{
    /// <summary>
    /// Comment from team to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamPlayerInviteModel, UpdateTeamPlayerInviteDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment));
}