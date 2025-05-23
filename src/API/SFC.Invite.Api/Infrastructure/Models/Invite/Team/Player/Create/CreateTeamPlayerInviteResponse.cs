using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Create;

/// <summary>
/// **Create** team player invite response.
/// </summary>
public class CreateTeamPlayerInviteResponse :
    BaseErrorResponse, IMapFrom<CreateTeamPlayerInviteViewModel>
{
    /// <summary>
    /// Team player invite model.
    /// </summary>
    public TeamPlayerInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerInviteViewModel, CreateTeamPlayerInviteResponse>()
                                                   .IgnoreAllNonExisting();
}