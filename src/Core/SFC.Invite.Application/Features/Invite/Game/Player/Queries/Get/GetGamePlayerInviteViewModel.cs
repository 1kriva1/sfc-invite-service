using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Common.Dto;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Get;
public class GetGamePlayerInviteViewModel : IMapFrom<GamePlayerInvite>
{
    public required GamePlayerInviteDto Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerInvite, GetGamePlayerInviteViewModel>()
                                                   .ForMember(p => p.Invite, d => d.MapFrom(z => z));
}