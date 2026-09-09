namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;
public class GetGamePlayerInvitesInviteFilterDto
{
    public IEnumerable<int> Statuses { get; set; } = [];
}