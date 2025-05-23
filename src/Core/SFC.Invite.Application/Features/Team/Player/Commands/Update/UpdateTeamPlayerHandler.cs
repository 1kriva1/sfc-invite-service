using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerHandler(IMapper mapper, ITeamPlayerRepository teamPlayerRepository)
    : IRequestHandler<UpdateTeamPlayerCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerRepository _teamPlayerRepository = teamPlayerRepository;

    public async Task Handle(UpdateTeamPlayerCommand request, CancellationToken cancellationToken)
    {
        TeamPlayer teamPlayer = await _teamPlayerRepository
            .GetByIdAsync(request.TeamPlayer.TeamId, request.TeamPlayer.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.TeamPlayerNotFound);

        TeamPlayer updatedTeamPlayer = _mapper.Map(request.TeamPlayer, teamPlayer);

        await _teamPlayerRepository.UpdateAsync(updatedTeamPlayer)
                                   .ConfigureAwait(false);
    }
}