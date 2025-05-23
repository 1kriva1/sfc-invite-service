using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Create;

/// <summary>
/// **Create** team player invite model.
/// </summary>
public class CreateTeamPlayerInviteModel : IMapTo<CreateTeamPlayerInviteDto>
{
    /// <summary>
    /// Comment from team to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerInviteModel, CreateTeamPlayerInviteDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment));
}