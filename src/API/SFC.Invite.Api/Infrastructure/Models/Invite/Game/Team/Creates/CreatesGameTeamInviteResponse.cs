using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Creates;

/// <summary>
/// **Create** Game Team invite response.
/// </summary>
public class CreatesGameTeamInviteResponse :
    BaseErrorResponse, IMapFrom<CreatesGameTeamInviteViewModel>
{
    /// <summary>
    /// Game Team invite models.
    /// </summary>
    public IEnumerable<GameTeamInviteModel> Invites { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGameTeamInviteViewModel, CreatesGameTeamInviteResponse>()
                                                   .IgnoreAllNonExisting();
}