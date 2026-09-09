using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Game.General;
using SFC.Invite.Api.Infrastructure.Models.Team.General;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Common.Dto;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Common;

/// <summary>
/// Game Team invite model.
/// </summary>
public class GameTeamInviteModel : IMapFrom<GameTeamInviteDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game invite related to this Team.
    /// </summary>
    public required TeamModel Team { get; set; }

    /// <summary>
    /// Game invite related to this Game.
    /// </summary>
    public required GameModel Game { get; set; }

    /// <summary>
    /// Game Team invite status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public required string GameComment { get; set; }

    /// <summary>
    /// Comment from Team to Game if he/she refuse invite.
    /// </summary>
    public string? TeamComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamInviteDto, GameTeamInviteModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}