using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Update.Refuse;

/// <summary>
/// **Refuse** Game Team invite request.
/// </summary>
public class RefuseGameTeamInviteRequest : IMapTo<UpdateGameTeamInviteCommand>
{
    /// <summary>
    /// Refuse Game Team invite model.
    /// </summary>
    public RefuseGameTeamInviteModel Invite { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<RefuseGameTeamInviteRequest, UpdateGameTeamInviteCommand>()
                                                   .IgnoreAllNonExisting();
}