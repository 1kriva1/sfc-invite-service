using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;
public class CreatesGamePlayerInviteViewModel : IMapFrom<IEnumerable<GamePlayerInvite>>
{
    public required IEnumerable<GamePlayerInviteDto> Invites { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<IEnumerable<GamePlayerInvite>, CreatesGamePlayerInviteViewModel>()
                                                   .ForMember(p => p.Invites, d => d.MapFrom(z => z));
}