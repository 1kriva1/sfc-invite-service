namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamInvitesInviteFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];
}