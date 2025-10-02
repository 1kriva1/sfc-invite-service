using AutoMapper;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.GetAll;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.GetAll;

/// <summary>
/// **Get** all team player invites response.
/// </summary>
public class GetAllTeamPlayerInvitesResponse :
    BaseErrorResponse, IMapFrom<GetAllTeamPlayerInvitesViewModel>
{
    /// <summary>
    /// Team player invite models.
    /// </summary>
    public IEnumerable<TeamPlayerInviteModel> Invites { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetAllTeamPlayerInvitesViewModel, GetAllTeamPlayerInvitesResponse>()
                                                   .IgnoreAllNonExisting();
}