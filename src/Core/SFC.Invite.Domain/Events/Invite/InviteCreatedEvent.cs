﻿using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Events.Invite;
public class InviteCreatedEvent(InviteEntity entity) : BaseEvent
{
    public InviteEntity Invite { get; } = entity;
}
