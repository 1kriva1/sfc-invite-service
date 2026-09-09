using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Invite.Game.Team.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Domain.Events.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;
public class CreateGameTeamInvitesCommandHandler(IMapper mapper, IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<CreatesGameTeamInviteCommand, CreatesGameTeamInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task<CreatesGameTeamInviteViewModel> Handle(CreatesGameTeamInviteCommand request, CancellationToken cancellationToken)
    {
        GameTeamInvite[] invites = [.. request.Invites.Select(MapGameTeamInvite)];

        await _gameTeamInviteRepository.AddRangeAsync(invites)
                                         .ConfigureAwait(false);

        IEnumerable<GameTeamInvite> result = await _gameTeamInviteRepository
            .GetByIdsAsync(invites.Select(i => i.Id))
            .ConfigureAwait(true);

        return _mapper.Map<CreatesGameTeamInviteViewModel>(result);
    }

    private GameTeamInvite MapGameTeamInvite(CreatesGameTeamInviteDto invite)
    {
        GameTeamInvite entity = _mapper.Map<GameTeamInvite>(invite)
                                       .SetStatus(InviteStatusEnum.Actual);

        entity.AddDomainEvent(new GameTeamInviteCreatedEvent(entity));

        return entity;
    }
}