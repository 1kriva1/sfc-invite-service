using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;

namespace SFC.Invite.Application.Features.Invite.Queries.Get;
public class GetInviteQueryHandler(IMapper mapper, IInviteRepository inviteRepository)
    : IRequestHandler<GetInviteQuery, GetInviteViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IInviteRepository _inviteRepository = inviteRepository;

    public async Task<GetInviteViewModel> Handle(GetInviteQuery request, CancellationToken cancellationToken)
    {
        InviteEntity invite = await _inviteRepository.GetByIdAsync(request.InviteId).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.InviteNotFound);

        return _mapper.Map<GetInviteViewModel>(invite);
    }
}
