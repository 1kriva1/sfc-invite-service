using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Create;

/// <summary>
/// **Create** Game Team invite request.
/// </summary>
public class CreateGameTeamInviteRequest : IMapTo<CreateGameTeamInviteCommand>
{
    /// <summary>
    /// Game Team invite model.
    /// </summary>
    public required CreateGameTeamInviteModel Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamInviteRequest, CreateGameTeamInviteCommand>()
                                                   .IgnoreAllNonExisting();
}