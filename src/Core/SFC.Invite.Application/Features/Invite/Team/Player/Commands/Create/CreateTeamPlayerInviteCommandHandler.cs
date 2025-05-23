using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Invite.Team.Player.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Events.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
public class CreateTeamPlayerInviteCommandHandler(IMapper mapper, ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<CreateTeamPlayerInviteCommand, CreateTeamPlayerInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task<CreateTeamPlayerInviteViewModel> Handle(CreateTeamPlayerInviteCommand request, CancellationToken cancellationToken)
    {
        TeamPlayerInvite invite = _mapper.Map<TeamPlayerInvite>(request.Invite)
                                         .SetStatus(InviteStatusEnum.Actual);

        invite.AddDomainEvent(new TeamPlayerInviteCreatedEvent(invite));

        await _teamPlayerInviteRepository.AddAsync(invite)
                             .ConfigureAwait(false);

        return _mapper.Map<CreateTeamPlayerInviteViewModel>(invite);
    }
}