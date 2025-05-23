namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;
public class GetTeamPlayerInvitesInviteFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];
}