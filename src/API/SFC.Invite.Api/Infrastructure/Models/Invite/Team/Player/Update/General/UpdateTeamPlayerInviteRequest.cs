using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Update.General;

/// <summary>
/// **Update** team player invite request.
/// </summary>
public class UpdateTeamPlayerInviteRequest : IMapTo<UpdateTeamPlayerInviteCommand>
{
    /// <summary>
    /// Update team player invite model.
    /// </summary>
    public UpdateTeamPlayerInviteModel Invite { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamPlayerInviteRequest, UpdateTeamPlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}