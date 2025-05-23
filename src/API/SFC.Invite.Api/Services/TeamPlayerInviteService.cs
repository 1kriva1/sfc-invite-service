using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;
using SFC.Invite.Contracts.Headers;
using SFC.Invite.Contracts.Messages.Invite.Team.Player.Find;
using SFC.Invite.Contracts.Messages.Invite.Team.Player.Get;
using SFC.Invite.Infrastructure.Constants;

using static SFC.Invite.Contracts.Services.TeamPlayerInviteService;

namespace SFC.Invite.Api.Services;

[Authorize(Policy.General)]
public class TeamPlayerInviteService(IMapper mapper, ISender mediator) : TeamPlayerInviteServiceBase
{
    public override async Task<GetTeamPlayerInviteResponse> GetTeamPlayerInvite(GetTeamPlayerInviteRequest request, ServerCallContext context)
    {
        GetTeamPlayerInviteQuery query = mapper.Map<GetTeamPlayerInviteQuery>(request);

        GetTeamPlayerInviteViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Invite));

        return mapper.Map<GetTeamPlayerInviteResponse>(model);
    }

    public override async Task<GetTeamPlayerInvitesResponse> GetTeamPlayerInvites(GetTeamPlayerInvitesRequest request, ServerCallContext context)
    {
        GetTeamPlayerInvitesQuery query = mapper.Map<GetTeamPlayerInvitesQuery>(request);

        GetTeamPlayerInvitesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetTeamPlayerInvitesResponse>(result);
    }
}