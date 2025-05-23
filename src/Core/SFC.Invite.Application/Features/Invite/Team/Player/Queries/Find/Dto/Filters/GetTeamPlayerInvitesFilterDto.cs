using SFC.Invite.Application.Common.Dto.Player.Filters;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;
public class GetTeamPlayerInvitesFilterDto
{
    public GetTeamPlayerInvitesInviteFilterDto? Invite { get; set; }

    public PlayerFilterDto? Player { get; set; }
}