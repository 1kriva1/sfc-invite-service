using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Get;
public class GetGameTeamInviteQueryHandler(IMapper mapper, IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<GetGameTeamInviteQuery, GetGameTeamInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task<GetGameTeamInviteViewModel> Handle(GetGameTeamInviteQuery request, CancellationToken cancellationToken)
    {
        GameTeamInvite invite = await _gameTeamInviteRepository
            .GetByIdAsync(request.Id, request.GameId, request.TeamId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.InviteNotFound);

        return _mapper.Map<GetGameTeamInviteViewModel>(invite);
    }
}