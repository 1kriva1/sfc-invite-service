using SFC.Invite.Application.Common.Dto.Player.General.Filters;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;
public class GetGamePlayerInvitesFilterDto
{
    public long GameId { get; set; }

    public GetGamePlayerInvitesInviteFilterDto? Invite { get; set; }

    public PlayerFilterDto? Player { get; set; }
}