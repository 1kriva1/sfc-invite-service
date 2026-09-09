using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Creates;

/// <summary>
/// **Creates** Game Team invites request.
/// </summary>
public class CreatesGameTeamInviteRequest : IMapTo<CreatesGameTeamInviteCommand>
{
    /// <summary>
    /// Game Team invite model.
    /// </summary>
    public required IEnumerable<CreatesGameTeamInviteModel> Invites { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGameTeamInviteRequest, CreatesGameTeamInviteCommand>()
                                                   .IgnoreAllNonExisting();
}