using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;
public class UpdateGameTeamInviteDto : IMapTo<GameTeamInvite>
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public int Status { get; set; }

    public string? TeamComment { get; set; }

    public string? GameComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamInviteDto, GameTeamInvite>()
                                                   .ForMember(dest => dest.GameComment, opt => opt.Condition(src => src.GameComment != null))
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}