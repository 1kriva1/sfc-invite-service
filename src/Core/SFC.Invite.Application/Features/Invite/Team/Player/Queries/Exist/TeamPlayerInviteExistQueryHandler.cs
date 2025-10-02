using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Exist;
public class TeamPlayerInviteExistQueryHandler(IMapper mapper, ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<TeamPlayerInviteExistQuery, TeamPlayerInviteExistViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task<TeamPlayerInviteExistViewModel> Handle(TeamPlayerInviteExistQuery request, CancellationToken cancellationToken)
    {
        bool exist = await _teamPlayerInviteRepository.AnyAsync(request.TeamId, request.PlayerId, request.Status).ConfigureAwait(true);
        return _mapper.Map<TeamPlayerInviteExistViewModel>(exist);
    }
}