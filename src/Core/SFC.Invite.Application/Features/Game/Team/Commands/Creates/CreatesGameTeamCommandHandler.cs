using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Invite.Domain.Entities.Game.Team;
using SFC.Invite.Domain.Events.Game.Team;

namespace SFC.Invite.Application.Features.Game.Team.Commands.Creates;

public class CreatesGameTeamCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IGameTeamRepository gameTeamRepository) : IRequestHandler<CreatesGameTeamCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IGameTeamRepository _gameTeamRepository = gameTeamRepository;

    public async Task Handle(CreatesGameTeamCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<GameTeam> gameTeams = _mapper.Map<IEnumerable<GameTeam>>(request.GameTeams);

        await _gameTeamRepository.AddRangeIfNotExistsAsync([.. gameTeams])
                               .ConfigureAwait(false);

        GameTeamsCreatedEvent @event = new(gameTeams);

        await _mediator.Publish(@event, cancellationToken)
                       .ConfigureAwait(false);
    }
}