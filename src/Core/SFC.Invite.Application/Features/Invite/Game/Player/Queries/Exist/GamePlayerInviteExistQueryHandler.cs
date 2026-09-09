using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Exist;
public class GamePlayerInviteExistQueryHandler(IMapper mapper, IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<GamePlayerInviteExistQuery, GamePlayerInviteExistViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task<GamePlayerInviteExistViewModel> Handle(GamePlayerInviteExistQuery request, CancellationToken cancellationToken)
    {
        bool exist = await _gamePlayerInviteRepository.AnyAsync(request.GameId, request.PlayerId, request.Status).ConfigureAwait(true);
        return _mapper.Map<GamePlayerInviteExistViewModel>(exist);
    }
}