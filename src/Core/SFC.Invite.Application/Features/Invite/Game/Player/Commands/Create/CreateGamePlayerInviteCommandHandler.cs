using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Features.Invite.Game.Player.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Domain.Events.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;
public class CreateGamePlayerInviteCommandHandler(IMapper mapper, IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<CreateGamePlayerInviteCommand, CreateGamePlayerInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task<CreateGamePlayerInviteViewModel> Handle(CreateGamePlayerInviteCommand request, CancellationToken cancellationToken)
    {
        GamePlayerInvite invite = _mapper.Map<GamePlayerInvite>(request.Invite)
                                         .SetStatus(InviteStatusEnum.Actual);

        invite.AddDomainEvent(new GamePlayerInviteCreatedEvent(invite));

        await _gamePlayerInviteRepository.AddAsync(invite)
                             .ConfigureAwait(false);

        GamePlayerInvite result = await _gamePlayerInviteRepository.GetByIdAsync(invite.Id)
                         .ConfigureAwait(false) ?? throw new NotFoundException(Localization.InviteNotFound);

        return _mapper.Map<CreateGamePlayerInviteViewModel>(result);
    }
}