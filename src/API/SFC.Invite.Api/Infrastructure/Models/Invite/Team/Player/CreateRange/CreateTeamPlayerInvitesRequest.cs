using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.CreateRange;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.CreateRange;

/// <summary>
/// **Create** team player invites request.
/// </summary>
public class CreateTeamPlayerInvitesRequest : IMapTo<CreateTeamPlayerInvitesCommand>
{
    /// <summary>
    /// Team player invite model.
    /// </summary>
    public required IEnumerable<CreateTeamPlayerInvitesModel> Invites { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerInvitesRequest, CreateTeamPlayerInvitesCommand>()
                                                   .IgnoreAllNonExisting();
}