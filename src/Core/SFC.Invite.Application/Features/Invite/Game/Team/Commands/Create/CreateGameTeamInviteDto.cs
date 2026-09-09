using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;
public class CreateGameTeamInviteDto : IMapTo<GameTeamInvite>
{
    public long GameId { get; set; }

    public long TeamId { get; set; }

    public string GameComment { get; set; } = default!;
}