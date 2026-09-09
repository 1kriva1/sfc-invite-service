using AutoMapper;

using MassTransit;

using SFC.Invite.Application.Interfaces.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Messages.Events.Invite.Game.Player;

namespace SFC.Invite.Infrastructure.Services.Invite.Game.Player;
public class GamePlayerInviteService(IMapper mapper, IPublishEndpoint publisher) : IGamePlayerInviteService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyGamePlayerInviteCreatedAsync(GamePlayerInvite invite, CancellationToken cancellationToken = default)
    {
        GamePlayerInviteCreated @event = _mapper.Map<GamePlayerInviteCreated>(invite);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyGamePlayerInviteUpdatedAsync(GamePlayerInvite invite, CancellationToken cancellationToken = default)
    {
        GamePlayerInviteUpdated @event = _mapper.Map<GamePlayerInviteUpdated>(invite);
        return _publisher.Publish(@event, cancellationToken);
    }
}