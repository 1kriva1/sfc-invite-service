using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Events.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;
public class UpdateTeamPlayerInviteCommandHandler(IMapper mapper, ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<UpdateTeamPlayerInviteCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task Handle(UpdateTeamPlayerInviteCommand request, CancellationToken cancellationToken)
    {
        TeamPlayerInvite invite = await _teamPlayerInviteRepository
             .GetByIdAsync(request.Invite.Id, request.Invite.TeamId, request.Invite.PlayerId).ConfigureAwait(true)
                 ?? throw new NotFoundException(Localization.InviteNotFound);

        TeamPlayerInvite updatedInvite = _mapper.Map(request.Invite, invite);

        updatedInvite.AddDomainEvent(new TeamPlayerInviteUpdatedEvent(updatedInvite));

        await _teamPlayerInviteRepository.UpdateAsync(updatedInvite)
                                         .ConfigureAwait(false);
    }
}