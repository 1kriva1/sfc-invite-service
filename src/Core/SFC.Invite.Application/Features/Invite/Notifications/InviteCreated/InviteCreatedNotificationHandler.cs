using MediatR;

using SFC.Invite.Domain.Events.Invite;

namespace SFC.Invite.Application.Features.Invite.Notifications.InviteCreated;
public class InviteCreatedNotificationHandler : INotificationHandler<InviteCreatedEvent>
{
    public Task Handle(InviteCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
