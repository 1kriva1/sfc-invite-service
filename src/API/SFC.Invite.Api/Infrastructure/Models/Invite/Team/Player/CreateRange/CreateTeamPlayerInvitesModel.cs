using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.CreateRange;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.CreateRange;

/// <summary>
/// **Create** team player invites model.
/// </summary>
public class CreateTeamPlayerInvitesModel : IMapTo<CreateTeamPlayerInvitesDto>
{
    /// <summary>
    /// Player for which team send invite.
    /// </summary>
    public long Player { get; set; }

    /// <summary>
    /// Comment from team to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerInvitesModel, CreateTeamPlayerInvitesDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment))
                                                   .ForMember(p => p.PlayerId, d => d.MapFrom(z => z.Player));
}