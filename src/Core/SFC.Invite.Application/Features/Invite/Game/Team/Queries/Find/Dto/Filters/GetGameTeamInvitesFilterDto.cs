using SFC.Invite.Application.Common.Dto.Team.General.Filters;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamInvitesFilterDto
{
    public long GameId { get; set; }

    public GetGameTeamInvitesInviteFilterDto? Invite { get; set; }

    public TeamFilterDto? Team { get; set; }
}