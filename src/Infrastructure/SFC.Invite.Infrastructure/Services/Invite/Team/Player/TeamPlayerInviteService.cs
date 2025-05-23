using AutoMapper;

using MassTransit;

using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Messages.Events.Invite.Team.Player;

namespace SFC.Invite.Infrastructure.Services.Invite.Team.Player;
public class TeamPlayerInviteService(IMapper mapper, IPublishEndpoint publisher) : ITeamPlayerInviteService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyTeamPlayerInviteCreatedAsync(TeamPlayerInvite invite, CancellationToken cancellationToken = default)
    {
        TeamPlayerInviteCreated @event = _mapper.Map<TeamPlayerInviteCreated>(invite);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyTeamPlayerInviteUpdatedAsync(TeamPlayerInvite invite, CancellationToken cancellationToken = default)
    {
        TeamPlayerInviteUpdated @event = _mapper.Map<TeamPlayerInviteUpdated>(invite);
        return _publisher.Publish(@event, cancellationToken);
    }
}