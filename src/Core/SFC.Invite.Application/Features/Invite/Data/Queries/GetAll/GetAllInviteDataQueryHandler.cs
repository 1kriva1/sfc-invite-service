using AutoMapper;

using MediatR;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Features.Invite.Data.Queries.Common.Dto;
using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Data.Models;

namespace SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;

public class GetAllInviteDataQueryHandler(IMapper mapper, IInviteDataService inviteDataService)
    : IRequestHandler<GetAllInviteDataQuery, GetAllInviteDataViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IInviteDataService _inviteDataService = inviteDataService;

    public async Task<GetAllInviteDataViewModel> Handle(GetAllInviteDataQuery request, CancellationToken cancellationToken)
    {
        GetAllInviteDataModel model = await _inviteDataService.GetAllInviteDataAsync().ConfigureAwait(true);

        return new GetAllInviteDataViewModel
        {
            InviteStatuses = _mapper.Map<IEnumerable<DataValueDto>>(model.InviteStatuses.Localize())
        };
    }
}