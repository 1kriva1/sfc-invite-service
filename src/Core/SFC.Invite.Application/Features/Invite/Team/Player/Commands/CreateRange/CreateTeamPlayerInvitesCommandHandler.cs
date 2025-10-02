using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
using SFC.Invite.Application.Features.Invite.Team.Player.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Events.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.CreateRange;
public class CreateTeamPlayerInvitesCommandHandler(IMapper mapper, ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<CreateTeamPlayerInvitesCommand, CreateTeamPlayerInvitesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task<CreateTeamPlayerInvitesViewModel> Handle(CreateTeamPlayerInvitesCommand request, CancellationToken cancellationToken)
    {
        TeamPlayerInvite[] invites = request.Invites.Select(invite => MapTeamPlayerInvite(invite))
                                                    .ToArray();

        await _teamPlayerInviteRepository.AddRangeAsync(invites)
                                         .ConfigureAwait(false);

        return _mapper.Map<CreateTeamPlayerInvitesViewModel>(invites);
    }

    private TeamPlayerInvite MapTeamPlayerInvite(CreateTeamPlayerInvitesDto invite)
    {
        TeamPlayerInvite entity = _mapper.Map<TeamPlayerInvite>(invite)
                                         .SetStatus(InviteStatusEnum.Actual);

        entity.AddDomainEvent(new TeamPlayerInviteCreatedEvent(entity));

        return entity;
    }
}