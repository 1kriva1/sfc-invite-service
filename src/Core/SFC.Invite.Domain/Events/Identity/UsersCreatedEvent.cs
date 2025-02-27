using SFC.Invite.Domain.Common;
using SFC.Invite.Domain.Entities.Identity;

namespace SFC.Invite.Domain.Events.Identity;
public class UsersCreatedEvent(IEnumerable<User> users) : BaseEvent
{
    public IEnumerable<User> Users { get; } = users;
}
