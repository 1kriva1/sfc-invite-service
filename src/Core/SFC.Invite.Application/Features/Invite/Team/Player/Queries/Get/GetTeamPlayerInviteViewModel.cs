using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;
public class GetTeamPlayerInviteViewModel : IMapFrom<TeamPlayerInvite>
{
    public required TeamPlayerInviteDto Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayerInvite, GetTeamPlayerInviteViewModel>()
                                                   .ForMember(p => p.Invite, d => d.MapFrom(z => z));
}