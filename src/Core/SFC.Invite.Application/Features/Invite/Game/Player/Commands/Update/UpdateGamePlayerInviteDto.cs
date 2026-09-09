using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;
public class UpdateGamePlayerInviteDto : IMapTo<GamePlayerInvite>
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int Status { get; set; }

    public string? PlayerComment { get; set; }

    public string? GameComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGamePlayerInviteDto, GamePlayerInvite>()
                                                   .ForMember(dest => dest.GameComment, opt => opt.Condition(src => src.GameComment != null))
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}