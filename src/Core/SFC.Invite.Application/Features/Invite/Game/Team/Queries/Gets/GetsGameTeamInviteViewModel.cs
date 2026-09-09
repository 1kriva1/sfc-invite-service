using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Gets;
public class GetsGameTeamInviteViewModel : IMapFrom<IEnumerable<GameTeamInvite>>
{
    public required IEnumerable<GameTeamInviteDto> Invites { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<GameTeamInvite>, GetsGameTeamInviteViewModel>()
                                                   .ForMember(p => p.Invites, d => d.MapFrom(z => z));
}