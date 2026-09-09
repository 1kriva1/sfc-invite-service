using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;
public class CreateGamePlayerInviteViewModel : IMapFrom<GamePlayerInvite>
{
    public required GamePlayerInviteDto Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerInvite, CreateGamePlayerInviteViewModel>()
                                                   .ForMember(p => p.Invite, d => d.MapFrom(z => z));
}