using AutoMapper;

using MassTransit;

using SFC.Invite.Application.Interfaces.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Messages.Events.Invite.Game.Team;

namespace SFC.Invite.Infrastructure.Services.Invite.Game.Team;
public class GameTeamInviteService(IMapper mapper, IPublishEndpoint publisher) : IGameTeamInviteService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyGameTeamInviteCreatedAsync(GameTeamInvite invite, CancellationToken cancellationToken = default)
    {
        GameTeamInviteCreated @event = _mapper.Map<GameTeamInviteCreated>(invite);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyGameTeamInviteUpdatedAsync(GameTeamInvite invite, CancellationToken cancellationToken = default)
    {
        GameTeamInviteUpdated @event = _mapper.Map<GameTeamInviteUpdated>(invite);
        return _publisher.Publish(@event, cancellationToken);
    }
}