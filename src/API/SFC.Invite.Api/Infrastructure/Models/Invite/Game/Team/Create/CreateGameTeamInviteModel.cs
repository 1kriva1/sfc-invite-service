using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Create;

/// <summary>
/// **Create** Game Team invite model.
/// </summary>
public class CreateGameTeamInviteModel : IMapTo<CreateGameTeamInviteDto>
{
    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamInviteModel, CreateGameTeamInviteDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}