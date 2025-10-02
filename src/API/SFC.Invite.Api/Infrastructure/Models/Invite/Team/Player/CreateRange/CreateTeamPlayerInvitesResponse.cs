using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.CreateRange;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.CreateRange;

/// <summary>
/// **Create** team player invite response.
/// </summary>
public class CreateTeamPlayerInvitesResponse :
    BaseErrorResponse, IMapFrom<CreateTeamPlayerInviteViewModel>
{
    /// <summary>
    /// Team player invite models.
    /// </summary>
    public IEnumerable<TeamPlayerInviteModel> Invites { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerInvitesViewModel, CreateTeamPlayerInvitesResponse>()
                                                   .IgnoreAllNonExisting();
}