using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Game.Player;
using SFC.Invite.Domain.Events.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Notifications.GamePlayerInviteUpdated;
public class GamePlayerInviteUpdatedNotificationHandler(IGamePlayerInviteService gamePlayerInviteService) : INotificationHandler<GamePlayerInviteUpdatedEvent>
{
    private readonly IGamePlayerInviteService _gamePlayerInviteService = gamePlayerInviteService;

    public Task Handle(GamePlayerInviteUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _gamePlayerInviteService.NotifyGamePlayerInviteUpdatedAsync(notification.Invite, cancellationToken);
    }
}