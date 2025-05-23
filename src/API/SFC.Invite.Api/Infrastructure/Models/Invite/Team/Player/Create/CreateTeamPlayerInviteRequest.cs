using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Create;

/// <summary>
/// **Create** team player invite request.
/// </summary>
public class CreateTeamPlayerInviteRequest : IMapTo<CreateTeamPlayerInviteCommand>
{
    /// <summary>
    /// Team player invite model.
    /// </summary>
    public required CreateTeamPlayerInviteModel Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerInviteRequest, CreateTeamPlayerInviteCommand>()
                                                   .IgnoreAllNonExisting();
}