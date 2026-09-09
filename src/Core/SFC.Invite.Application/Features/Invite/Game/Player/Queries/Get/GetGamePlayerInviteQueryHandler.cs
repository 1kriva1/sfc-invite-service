using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Get;
public class GetGamePlayerInviteQueryHandler(IMapper mapper, IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<GetGamePlayerInviteQuery, GetGamePlayerInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task<GetGamePlayerInviteViewModel> Handle(GetGamePlayerInviteQuery request, CancellationToken cancellationToken)
    {
        GamePlayerInvite invite = await _gamePlayerInviteRepository
            .GetByIdAsync(request.Id, request.GameId, request.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.InviteNotFound);

        return _mapper.Map<GetGamePlayerInviteViewModel>(invite);
    }
}