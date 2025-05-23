using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Update.Refuse;

/// <summary>
/// **Refuse** team player invite request.
/// </summary>
public class RefuseTeamPlayerInviteRequest : IMapTo<UpdateTeamPlayerInviteCommand>
{
    /// <summary>
    /// Refuse team player invite model.
    /// </summary>
    public RefuseTeamPlayerInviteModel Invite { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RefuseTeamPlayerInviteRequest, UpdateTeamPlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}