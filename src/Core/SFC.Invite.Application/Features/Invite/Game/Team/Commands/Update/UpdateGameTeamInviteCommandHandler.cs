using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Domain.Events.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;
public class UpdateGameTeamInviteCommandHandler(IMapper mapper, IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<UpdateGameTeamInviteCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task Handle(UpdateGameTeamInviteCommand request, CancellationToken cancellationToken)
    {
        GameTeamInvite invite = await _gameTeamInviteRepository
             .GetByIdAsync(request.Invite.Id, request.Invite.GameId, request.Invite.TeamId).ConfigureAwait(true)
                 ?? throw new NotFoundException(Localization.InviteNotFound);

        GameTeamInvite updatedInvite = _mapper.Map(request.Invite, invite);

        updatedInvite.AddDomainEvent(new GameTeamInviteUpdatedEvent(updatedInvite));

        await _gameTeamInviteRepository.UpdateAsync(updatedInvite)
                                         .ConfigureAwait(false);
    }
}