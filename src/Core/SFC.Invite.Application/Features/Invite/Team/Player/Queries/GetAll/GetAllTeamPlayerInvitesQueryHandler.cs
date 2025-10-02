using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.GetAll;
public class GetAllTeamPlayerInvitesQueryHandler(IMapper mapper, ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<GetAllTeamPlayerInvitesQuery, GetAllTeamPlayerInvitesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task<GetAllTeamPlayerInvitesViewModel> Handle(GetAllTeamPlayerInvitesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TeamPlayerInvite> teamPlayerInvites = await _teamPlayerInviteRepository.ListAllAsync(request.TeamId).ConfigureAwait(true);
        return _mapper.Map<GetAllTeamPlayerInvitesViewModel>(teamPlayerInvites);
    }
}