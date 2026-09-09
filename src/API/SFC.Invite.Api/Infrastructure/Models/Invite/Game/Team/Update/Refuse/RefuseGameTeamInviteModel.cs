using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Update.Refuse;

/// <summary>
/// **Refuse** Game Team invite model.
/// </summary>
public class RefuseGameTeamInviteModel : IMapTo<UpdateGameTeamInviteDto>
{
    /// <summary>
    /// Comment from Team to explain why he/she is refuse Game invite.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RefuseGameTeamInviteModel, UpdateGameTeamInviteDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment));
}