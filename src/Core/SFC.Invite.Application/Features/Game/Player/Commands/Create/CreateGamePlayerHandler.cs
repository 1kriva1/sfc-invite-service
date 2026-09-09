using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Invite.Domain.Entities.Game.Player;

namespace SFC.Invite.Application.Features.Game.Player.Commands.Create;
public class CreateGamePlayerHandler(
    IMapper mapper,
    IGamePlayerRepository gamePlayerRepository)
    : IRequestHandler<CreateGamePlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRepository _gamePlayerRepository = gamePlayerRepository;

    public async Task Handle(CreateGamePlayerCommand request, CancellationToken cancellationToken)
    {
        GamePlayer gamePlayer = _mapper.Map<GamePlayer>(request.GamePlayer);

        await _gamePlayerRepository.AddAsync(gamePlayer)
                                   .ConfigureAwait(true);
    }
}