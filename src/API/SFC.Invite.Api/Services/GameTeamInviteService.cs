using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Get;
using SFC.Invite.Contracts.Headers;
using SFC.Invite.Contracts.Messages.Invite.Game.Team.Find;
using SFC.Invite.Contracts.Messages.Invite.Game.Team.Get;
using SFC.Invite.Infrastructure.Constants;

using static SFC.Invite.Contracts.Services.GameTeamInviteService;

namespace SFC.Invite.Api.Services;

[Authorize(Policy.General)]
public class GameTeamInviteService(IMapper mapper, ISender mediator) : GameTeamInviteServiceBase
{
    public override async Task<GetGameTeamInviteResponse> GetGameTeamInvite(GetGameTeamInviteRequest request, ServerCallContext context)
    {
        GetGameTeamInviteQuery query = mapper.Map<GetGameTeamInviteQuery>(request);

        GetGameTeamInviteViewModel model = await mediator.Send(query).ConfigureAwait(true);

        context.AddAuditableHeaderIfRequested(mapper.Map<AuditableHeader>(model.Invite));

        return mapper.Map<GetGameTeamInviteResponse>(model);
    }

    public override async Task<GetGameTeamInvitesResponse> GetGameTeamInvites(GetGameTeamInvitesRequest request, ServerCallContext context)
    {
        GetGameTeamInvitesQuery query = mapper.Map<GetGameTeamInvitesQuery>(request);

        GetGameTeamInvitesViewModel result = await mediator.Send(query).ConfigureAwait(true);

        context.AddPaginationHeader(mapper.Map<PaginationHeader>(result.Metadata));

        return mapper.Map<GetGameTeamInvitesResponse>(result);
    }
}