using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Game.General;
using SFC.Invite.Api.Infrastructure.Models.Player;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Common.Dto;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Common;

/// <summary>
/// Game player invite model.
/// </summary>
public class GamePlayerInviteModel : IMapFrom<GamePlayerInviteDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game invite related to this player.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Game invite related to this Game.
    /// </summary>
    public required GameModel Game { get; set; }

    /// <summary>
    /// Game player invite status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public required string GameComment { get; set; }

    /// <summary>
    /// Comment from player to Game if he/she refuse invite.
    /// </summary>
    public string? PlayerComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerInviteDto, GamePlayerInviteModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}