using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Game.Team;
using SFC.Invite.Domain.Events.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Notifications.GameTeamInviteCreated;
public class GameTeamInviteCreatedNotificationHandler(IGameTeamInviteService gameTeamInviteService) : INotificationHandler<GameTeamInviteCreatedEvent>
{
    private readonly IGameTeamInviteService _gameTeamInviteService = gameTeamInviteService;

    public Task Handle(GameTeamInviteCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _gameTeamInviteService.NotifyGameTeamInviteCreatedAsync(notification.Invite, cancellationToken);
    }
}