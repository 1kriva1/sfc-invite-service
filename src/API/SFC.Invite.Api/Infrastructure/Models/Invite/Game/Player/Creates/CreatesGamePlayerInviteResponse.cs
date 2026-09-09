using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Creates;

/// <summary>
/// **Create** Game player invite response.
/// </summary>
public class CreatesGamePlayerInviteResponse :
    BaseErrorResponse, IMapFrom<CreatesGamePlayerInviteViewModel>
{
    /// <summary>
    /// Game player invite models.
    /// </summary>
    public IEnumerable<GamePlayerInviteModel> Invites { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGamePlayerInviteViewModel, CreatesGamePlayerInviteResponse>()
                                                   .IgnoreAllNonExisting();
}