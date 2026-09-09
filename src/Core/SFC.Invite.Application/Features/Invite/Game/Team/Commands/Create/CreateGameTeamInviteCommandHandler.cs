using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Features.Invite.Game.Team.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Domain.Events.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;
public class CreateGameTeamInviteCommandHandler(IMapper mapper, IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<CreateGameTeamInviteCommand, CreateGameTeamInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task<CreateGameTeamInviteViewModel> Handle(CreateGameTeamInviteCommand request, CancellationToken cancellationToken)
    {
        GameTeamInvite invite = _mapper.Map<GameTeamInvite>(request.Invite)
                                         .SetStatus(InviteStatusEnum.Actual);

        invite.AddDomainEvent(new GameTeamInviteCreatedEvent(invite));

        await _gameTeamInviteRepository.AddAsync(invite)
                             .ConfigureAwait(false);

        GameTeamInvite result = await _gameTeamInviteRepository.GetByIdAsync(invite.Id)
                         .ConfigureAwait(false) ?? throw new NotFoundException(Localization.InviteNotFound);

        return _mapper.Map<CreateGameTeamInviteViewModel>(result);
    }
}