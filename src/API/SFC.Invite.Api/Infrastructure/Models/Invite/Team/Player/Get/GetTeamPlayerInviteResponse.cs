using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** team player invite response.
/// </summary>
public class GetTeamPlayerInviteResponse :
    BaseErrorResponse, IMapFrom<GetTeamPlayerInviteViewModel>
{
    /// <summary>
    /// Team player invite model.
    /// </summary>
    public TeamPlayerInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayerInviteViewModel, GetTeamPlayerInviteResponse>()
                                                   .IgnoreAllNonExisting();
}