using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Infrastructure.Extensions;

namespace SFC.Invite.Infrastructure.Authorization.OwnInvite;
public class OwnInviteHandler(ITeamPlayerInviteRepository inviteRepository, IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<OwnInviteRequirement>
{
    private readonly ITeamPlayerInviteRepository _inviteRepository = inviteRepository;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnInviteRequirement requirement)
    {
        string? inviteIdValue = _httpContextAccessor.HttpContext?.GetRouteValue("id")?.ToString();

        if (!long.TryParse(inviteIdValue, out long inviteId))
        {
            context.Fail(new AuthorizationFailureReason(this, "Route does not have \"id\" parameter value."));
            return;
        }

        Guid? userId = _httpContextAccessor.GetUserId();

        if (!userId.HasValue)
        {
            context.Fail(new AuthorizationFailureReason(this, "User does not have NameIdentifier claim value."));
            return;
        }

        if (!await _inviteRepository.AnyAsync(inviteId, userId.Value).ConfigureAwait(true))
        {
            context.Fail(new AuthorizationFailureReason(this, $"User - {userId} does not related to this resource - {inviteId}."));
            return;
        }

        context.Succeed(requirement);
    }
}