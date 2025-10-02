using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Team.Player;
using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Api.Infrastructure.Models.Team.General;

/// <summary>
/// Team model.
/// </summary>
public class TeamModel : IMapFrom<TeamDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Team status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Team's profile model.
    /// </summary>
    public TeamProfileModel Profile { get; set; } = null!;

    public IEnumerable<TeamPlayerModel> Players { get; set; } = [];

    public void Mapping(Profile profile) => profile.CreateMap<TeamDto, TeamModel>()
                                                  .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}