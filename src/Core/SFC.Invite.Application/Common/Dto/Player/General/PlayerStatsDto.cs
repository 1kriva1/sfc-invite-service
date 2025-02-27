using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Application.Common.Dto.Player.General;

public class PlayerStatsDto : IMapFromReverse<PlayerEntity>
{
    public PlayerStatPointsDto Points { get; set; } = null!;

    public IEnumerable<PlayerStatValueDto> Values { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerEntity, PlayerStatsDto>()
            .ForMember(p => p.Values, d => d.MapFrom(z => z.Stats))
            .ReverseMap();
    }
}
