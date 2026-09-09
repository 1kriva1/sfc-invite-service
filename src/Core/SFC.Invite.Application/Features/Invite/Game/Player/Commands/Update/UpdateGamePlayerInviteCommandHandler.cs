using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Domain.Events.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;
public class UpdateGamePlayerInviteCommandHandler(IMapper mapper, IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<UpdateGamePlayerInviteCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task Handle(UpdateGamePlayerInviteCommand request, CancellationToken cancellationToken)
    {
        GamePlayerInvite invite = await _gamePlayerInviteRepository
             .GetByIdAsync(request.Invite.Id, request.Invite.GameId, request.Invite.PlayerId).ConfigureAwait(true)
                 ?? throw new NotFoundException(Localization.InviteNotFound);

        GamePlayerInvite updatedInvite = _mapper.Map(request.Invite, invite);

        updatedInvite.AddDomainEvent(new GamePlayerInviteUpdatedEvent(updatedInvite));

        await _gamePlayerInviteRepository.UpdateAsync(updatedInvite)
                                         .ConfigureAwait(false);
    }
}