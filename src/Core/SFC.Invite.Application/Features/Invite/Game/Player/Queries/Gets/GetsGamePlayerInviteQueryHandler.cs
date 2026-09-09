using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Gets;
public class GetsGamePlayerInviteQueryHandler(IMapper mapper, IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<GetsGamePlayerInviteQuery, GetsGamePlayerInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task<GetsGamePlayerInviteViewModel> Handle(GetsGamePlayerInviteQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GamePlayerInvite> GamePlayerInvites = await _gamePlayerInviteRepository.ListAllAsync(request.GameId).ConfigureAwait(true);
        return _mapper.Map<GetsGamePlayerInviteViewModel>(GamePlayerInvites);
    }
}