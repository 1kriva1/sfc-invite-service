using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Update.General;

/// <summary>
/// **Update** Game Team invite request.
/// </summary>
public class UpdateGameTeamInviteRequest : IMapTo<UpdateGameTeamInviteCommand>
{
    /// <summary>
    /// Update Game Team invite model.
    /// </summary>
    public UpdateGameTeamInviteModel Invite { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamInviteRequest, UpdateGameTeamInviteCommand>()
                                                   .IgnoreAllNonExisting();
}