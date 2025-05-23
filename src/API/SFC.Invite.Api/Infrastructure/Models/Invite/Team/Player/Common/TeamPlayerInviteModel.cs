using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Player.Result;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Common.Dto;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Common;

/// <summary>
/// Team player invite model.
/// </summary>
public class TeamPlayerInviteModel : IMapFrom<TeamPlayerInviteDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Team invite related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Team invite related to this team.
    /// </summary>
    public required TeamPlayerInviteTeamModel Team { get; set; }

    /// <summary>
    /// Team player invite status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Comment from team to player for invitation.
    /// </summary>
    public required string TeamComment { get; set; }

    /// <summary>
    /// Comment from player to team if he/she refuse invite.
    /// </summary>
    public string? PlayerComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamPlayerInviteDto, TeamPlayerInviteModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId))
                                                   .ForMember(p => p.Team, d => d.MapFrom(z => z.TeamId));
}