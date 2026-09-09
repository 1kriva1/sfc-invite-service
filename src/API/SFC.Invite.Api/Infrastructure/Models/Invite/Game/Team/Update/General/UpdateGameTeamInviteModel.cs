using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Update.General;

/// <summary>
/// **Update** Game Team invite model.
/// </summary>
public class UpdateGameTeamInviteModel : IMapTo<UpdateGameTeamInviteDto>
{
    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamInviteModel, UpdateGameTeamInviteDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}