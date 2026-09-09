using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Game.Player;
using SFC.Invite.Domain.Events.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Notifications.GamePlayerInviteCreated;
public class GamePlayerInviteCreatedNotificationHandler(IGamePlayerInviteService gamePlayerInviteService) : INotificationHandler<GamePlayerInviteCreatedEvent>
{
    private readonly IGamePlayerInviteService _gamePlayerInviteService = gamePlayerInviteService;

    public Task Handle(GamePlayerInviteCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _gamePlayerInviteService.NotifyGamePlayerInviteCreatedAsync(notification.Invite, cancellationToken);
    }
}