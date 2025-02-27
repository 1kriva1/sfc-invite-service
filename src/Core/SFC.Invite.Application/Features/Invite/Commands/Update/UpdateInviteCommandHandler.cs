using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;

namespace SFC.Invite.Application.Features.Invite.Commands.Update;
public class UpdateInviteCommandHandler(IMapper mapper, IInviteRepository inviteRepository)
    : IRequestHandler<UpdateInviteCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IInviteRepository _inviteRepository = inviteRepository;

    public async Task Handle(UpdateInviteCommand request, CancellationToken cancellationToken)
    {
        InviteEntity invite = await _inviteRepository.GetByIdAsync(request.InviteId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.InviteNotFound);

        InviteEntity updatedInvite = _mapper.Map(request.Invite, invite);

        await _inviteRepository.UpdateAsync(updatedInvite)
                            .ConfigureAwait(false);
    }
}
