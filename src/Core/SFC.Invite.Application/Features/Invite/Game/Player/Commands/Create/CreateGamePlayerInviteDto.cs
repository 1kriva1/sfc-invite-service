using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;
public class CreateGamePlayerInviteDto : IMapTo<GamePlayerInvite>
{
    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public string GameComment { get; set; } = default!;
}