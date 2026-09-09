using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Gets;
public class GetsGameTeamInviteQueryHandler(IMapper mapper, IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<GetsGameTeamInviteQuery, GetsGameTeamInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task<GetsGameTeamInviteViewModel> Handle(GetsGameTeamInviteQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GameTeamInvite> GameTeamInvites = await _gameTeamInviteRepository.ListAllAsync(request.GameId).ConfigureAwait(true);
        return _mapper.Map<GetsGameTeamInviteViewModel>(GameTeamInvites);
    }
}