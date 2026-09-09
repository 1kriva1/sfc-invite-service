using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Creates;

/// <summary>
/// **Creates** Game Team invite model.
/// </summary>
public class CreatesGameTeamInviteModel : IMapTo<CreatesGameTeamInviteDto>
{
    /// <summary>
    /// Team for which Game send invite.
    /// </summary>
    public long Team { get; set; }

    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGameTeamInviteModel, CreatesGameTeamInviteDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment))
                                                   .ForMember(p => p.TeamId, d => d.MapFrom(z => z.Team));
}