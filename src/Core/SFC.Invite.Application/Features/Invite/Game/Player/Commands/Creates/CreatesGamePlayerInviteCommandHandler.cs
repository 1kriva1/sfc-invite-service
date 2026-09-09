using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Invite.Game.Player.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Domain.Events.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;
public class CreateGamePlayerInvitesCommandHandler(IMapper mapper, IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<CreatesGamePlayerInviteCommand, CreatesGamePlayerInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task<CreatesGamePlayerInviteViewModel> Handle(CreatesGamePlayerInviteCommand request, CancellationToken cancellationToken)
    {
        GamePlayerInvite[] invites = [.. request.Invites.Select(MapGamePlayerInvite)];

        await _gamePlayerInviteRepository.AddRangeAsync(invites)
                                         .ConfigureAwait(false);

        IEnumerable<GamePlayerInvite> result = await _gamePlayerInviteRepository
            .GetByIdsAsync(invites.Select(i => i.Id))
            .ConfigureAwait(true);

        return _mapper.Map<CreatesGamePlayerInviteViewModel>(result);
    }

    private GamePlayerInvite MapGamePlayerInvite(CreatesGamePlayerInviteDto invite)
    {
        GamePlayerInvite entity = _mapper.Map<GamePlayerInvite>(invite)
                                         .SetStatus(InviteStatusEnum.Actual);

        entity.AddDomainEvent(new GamePlayerInviteCreatedEvent(entity));

        return entity;
    }
}