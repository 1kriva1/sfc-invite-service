using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Game.Team;
using SFC.Invite.Domain.Events.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Notifications.GameTeamInviteUpdated;
public class GameTeamInviteUpdatedNotificationHandler(IGameTeamInviteService gameTeamInviteService) : INotificationHandler<GameTeamInviteUpdatedEvent>
{
    private readonly IGameTeamInviteService _gameTeamInviteService = gameTeamInviteService;

    public Task Handle(GameTeamInviteUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _gameTeamInviteService.NotifyGameTeamInviteUpdatedAsync(notification.Invite, cancellationToken);
    }
}