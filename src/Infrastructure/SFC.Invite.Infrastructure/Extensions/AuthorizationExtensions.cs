using Microsoft.AspNetCore.Authorization;

using SFC.Invite.Infrastructure.Authorization;

namespace SFC.Invite.Infrastructure.Extensions;
public static class AuthorizationExtensions
{
    public static void AddGeneralPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(options);

        PolicyModel general = AuthorizationPolicies.General(claims);
        options.AddPolicy(general.Name, general.Policy);
    }

    public static void AddOwnInvitePolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownInvite = AuthorizationPolicies.OwnInvite(claims);
        options.AddPolicy(ownInvite.Name, ownInvite.Policy);
    }

    public static void AddOwnPlayerPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownTeam = AuthorizationPolicies.OwnPlayer(claims);
        options.AddPolicy(ownTeam.Name, ownTeam.Policy);
    }

    public static void AddOwnTeamPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownTeam = AuthorizationPolicies.OwnTeam(claims);
        options.AddPolicy(ownTeam.Name, ownTeam.Policy);
    }
}