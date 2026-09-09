using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Create;

/// <summary>
/// **Create** Game Team invite response.
/// </summary>
public class CreateGameTeamInviteResponse :
    BaseErrorResponse, IMapFrom<CreateGameTeamInviteViewModel>
{
    /// <summary>
    /// Game Team invite model.
    /// </summary>
    public GameTeamInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamInviteViewModel, CreateGameTeamInviteResponse>()
                                                   .IgnoreAllNonExisting();
}