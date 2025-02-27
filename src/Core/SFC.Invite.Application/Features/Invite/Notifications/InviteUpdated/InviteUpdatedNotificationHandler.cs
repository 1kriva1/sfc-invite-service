using MediatR;

using SFC.Invite.Domain.Events.Invite;

namespace SFC.Invite.Application.Features.Invite.Notifications.InviteUpdated;
public class InviteUpdatedNotificationHandler : INotificationHandler<InviteUpdatedEvent>
{
    public Task Handle(InviteUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
