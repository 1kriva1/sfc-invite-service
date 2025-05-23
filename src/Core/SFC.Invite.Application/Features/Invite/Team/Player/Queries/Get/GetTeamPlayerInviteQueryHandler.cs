using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;
public class GetTeamPlayerInviteQueryHandler(IMapper mapper, ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<GetTeamPlayerInviteQuery, GetTeamPlayerInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task<GetTeamPlayerInviteViewModel> Handle(GetTeamPlayerInviteQuery request, CancellationToken cancellationToken)
    {
        TeamPlayerInvite invite = await _teamPlayerInviteRepository
            .GetByIdAsync(request.Id, request.TeamId, request.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.InviteNotFound);

        return _mapper.Map<GetTeamPlayerInviteViewModel>(invite);
    }
}