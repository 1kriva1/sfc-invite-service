using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.GetAll;
public class GetAllTeamPlayerInvitesViewModel : IMapFrom<IEnumerable<TeamPlayerInvite>>
{
    public required IEnumerable<TeamPlayerInviteDto> Invites { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<TeamPlayerInvite>, GetAllTeamPlayerInvitesViewModel>()
                                                   .ForMember(p => p.Invites, d => d.MapFrom(z => z));
}