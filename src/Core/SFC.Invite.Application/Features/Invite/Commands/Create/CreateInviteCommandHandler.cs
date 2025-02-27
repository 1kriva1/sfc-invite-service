using AutoMapper;

using MediatR;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;
using SFC.Invite.Domain.Events.Invite;

namespace SFC.Invite.Application.Features.Invite.Commands.Create;
public class CreateInviteCommandHandler(
    IMapper mapper,
    IInviteRepository inviteRepository)
    : IRequestHandler<CreateInviteCommand, CreateInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IInviteRepository _inviteRepository = inviteRepository;

    public async Task<CreateInviteViewModel> Handle(CreateInviteCommand request, CancellationToken cancellationToken)
    {
        InviteEntity invite = _mapper.Map<InviteEntity>(request.Invite);

        invite.AddDomainEvent(new InviteCreatedEvent(invite));

        await _inviteRepository.AddAsync(invite)
                             .ConfigureAwait(false);

        return _mapper.Map<CreateInviteViewModel>(invite);
    }
}
