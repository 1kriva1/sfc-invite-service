using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Get;
using SFC.Invite.Contracts.Headers;
using SFC.Invite.Contracts.Messages.Invite.Game.Player.Find;
using SFC.Invite.Contracts.Messages.Invite.Game.Player.Get;
using SFC.Invite.Infrastructure.Constants;

using static SFC.Invite.Contracts.Services.GamePlayerInviteService;

namespace SFC.Invite.Api.Services;

[Authorize(Policy.General)]
public class GamePlayerInviteService(IMapper mapper, ISender mediator) : GamePlayerInviteServiceBase
{
    public override async Task<GetGamePlayerInviteResponse> GetGamePlayerInvite(GetGamePlayerInviteRequest request, ServerCallContext context)
    {
        GetGamePlayerInviteQuery query = mapper.Map<GetGamePlayerInviteQuery>(request);

        GetGamePlayerInviteViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Invite));

        return mapper.Map<GetGamePlayerInviteResponse>(model);
    }

    public override async Task<GetGamePlayerInvitesResponse> GetGamePlayerInvites(GetGamePlayerInvitesRequest request, ServerCallContext context)
    {
        GetGamePlayerInvitesQuery query = mapper.Map<GetGamePlayerInvitesQuery>(request);

        GetGamePlayerInvitesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetGamePlayerInvitesResponse>(result);
    }
}