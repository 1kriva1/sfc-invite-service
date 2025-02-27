using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Application.Features.Invite.Queries.Find;
using SFC.Invite.Application.Features.Invite.Queries.Get;
using SFC.Invite.Contracts.Headers;
using SFC.Invite.Contracts.Messages.Find;
using SFC.Invite.Contracts.Messages.Get;
using SFC.Invite.Infrastructure.Constants;

using static SFC.Invite.Contracts.Services.InviteService;

namespace SFC.Invite.Api.Services;

[Authorize(Policy.General)]
public class InviteService(IMapper mapper, ISender mediator) : InviteServiceBase
{
    public override async Task<GetInviteResponse> GetInvite(GetInviteRequest request, ServerCallContext context)
    {
        GetInviteQuery query = mapper.Map<GetInviteQuery>(request);

        GetInviteViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Invite));

        return mapper.Map<GetInviteResponse>(model);
    }

    public override async Task<GetInvitesResponse> GetInvites(GetInvitesRequest request, ServerCallContext context)
    {
        GetInvitesQuery query = mapper.Map<GetInvitesQuery>(request);

        GetInvitesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetInvitesResponse>(result);
    }
}