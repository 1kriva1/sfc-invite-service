using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;
using SFC.Invite.Contracts.Messages.Invite.Data.GetAll;
using SFC.Invite.Infrastructure.Constants;

using static SFC.Invite.Contracts.Services.InviteDataService;

namespace SFC.Invite.Api.Services;

[Authorize(Policy.General)]
public class InviteDataService(IMapper mapper, ISender mediator) : InviteDataServiceBase
{
    public override async Task<GetAllInviteDataResponse> GetAll(GetAllInviteDataRequest request, ServerCallContext context)
    {
        GetAllInviteDataQuery query = new();

        GetAllInviteDataViewModel model = await mediator.Send(query).ConfigureAwait(true);

        return mapper.Map<GetAllInviteDataResponse>(model);
    }
}