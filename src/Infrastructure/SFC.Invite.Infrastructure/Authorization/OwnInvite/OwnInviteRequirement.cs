using Microsoft.AspNetCore.Authorization;

namespace SFC.Invite.Infrastructure.Authorization.OwnInvite;
public class OwnInviteRequirement : IAuthorizationRequirement
{
    public OwnInviteRequirement() { }

    public override string ToString()
    {
        return "OwnInviteRequirement: Requires user has be owner of resource.";
    }
}
