using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;
public class CreateGameTeamInviteViewModel : IMapFrom<GameTeamInvite>
{
    public required GameTeamInviteDto Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamInvite, CreateGameTeamInviteViewModel>()
                                                   .ForMember(p => p.Invite, d => d.MapFrom(z => z));
}