using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Game.Player;
using SFC.Invite.Application.Common.Dto.Game.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game model.
/// </summary>
public class GameModel : IMapFrom<GameDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Game's profile model.
    /// </summary>
    public GameProfileModel Profile { get; set; } = null!;

    /// <summary>
    /// Game's players model.
    /// </summary>
    public IEnumerable<GamePlayerModel> GamePlayers { get; set; } = [];

    public void Mapping(Profile profile) => profile.CreateMap<GameDto, GameModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}