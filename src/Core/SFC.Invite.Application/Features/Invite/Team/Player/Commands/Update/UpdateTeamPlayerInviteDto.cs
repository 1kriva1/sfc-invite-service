using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;
public class UpdateTeamPlayerInviteDto : IMapTo<TeamPlayerInvite>
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int Status { get; set; }

    public string? PlayerComment { get; set; }

    public string? TeamComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamPlayerInviteDto, TeamPlayerInvite>()
                                                   .ForMember(dest => dest.TeamComment, opt => opt.Condition(src => src.TeamComment != null))
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}