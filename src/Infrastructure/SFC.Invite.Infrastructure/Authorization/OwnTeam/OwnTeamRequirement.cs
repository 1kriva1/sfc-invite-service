﻿using Microsoft.AspNetCore.Authorization;

namespace SFC.Invite.Infrastructure.Authorization.OwnTeam;
public class OwnTeamRequirement : IAuthorizationRequirement
{
    public OwnTeamRequirement() { }

    public override string ToString()
    {
        return "OwnTeamRequirement: Requires user has be owner of resource.";
    }
}