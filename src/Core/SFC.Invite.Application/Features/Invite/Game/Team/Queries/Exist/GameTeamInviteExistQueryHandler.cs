using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Exist;
public class GameTeamInviteExistQueryHandler(IMapper mapper, IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<GameTeamInviteExistQuery, GameTeamInviteExistViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task<GameTeamInviteExistViewModel> Handle(GameTeamInviteExistQuery request, CancellationToken cancellationToken)
    {
        bool exist = await _gameTeamInviteRepository.AnyAsync(request.GameId, request.TeamId, request.Status).ConfigureAwait(true);
        return _mapper.Map<GameTeamInviteExistViewModel>(exist);
    }
}