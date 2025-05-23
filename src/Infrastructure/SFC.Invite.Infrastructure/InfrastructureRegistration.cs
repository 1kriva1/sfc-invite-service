using System.Reflection;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Identity;
using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Player;
using SFC.Invite.Application.Interfaces.Reference;
using SFC.Invite.Application.Interfaces.Team.General;
using SFC.Invite.Application.Interfaces.Team.Player;
using SFC.Invite.Infrastructure.Authorization.OwnInvite;
using SFC.Invite.Infrastructure.Authorization.OwnPlayer;
using SFC.Invite.Infrastructure.Authorization.OwnTeam;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Extensions.Grpc;
using SFC.Invite.Infrastructure.Services.Common;
using SFC.Invite.Infrastructure.Services.Hosted;
using SFC.Invite.Infrastructure.Services.Identity;
using SFC.Invite.Infrastructure.Services.Invite.Data;
using SFC.Invite.Infrastructure.Services.Invite.Team.Player;
using SFC.Invite.Infrastructure.Services.Metadata;
using SFC.Invite.Infrastructure.Services.Player;
using SFC.Invite.Infrastructure.Services.Reference;
using SFC.Invite.Infrastructure.Services.Team.General;
using SFC.Invite.Infrastructure.Services.Team.Player;

namespace SFC.Invite.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAccessTokenManagement();

        builder.Services.AddRedis(builder.Configuration);

        builder.AddMassTransit();

        builder.Services.AddCache(builder.Configuration);

        builder.Services.AddGrpc(builder.Configuration, builder.Environment);

        builder.Services.AddSingleton<IUriService>(o =>
        {
            IHttpContextAccessor accessor = o.GetRequiredService<IHttpContextAccessor>();
            HttpRequest request = accessor.HttpContext!.Request;
            return new UriService(string.Concat(request.Scheme, "://", request.Host.ToUriComponent()));
        });

        // custom services
        builder.Services.AddTransient<IMetadataService, MetadataService>();
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserSeedService, UserSeedService>();
        builder.Services.AddTransient<IPlayerSeedService, PlayerSeedService>();
        builder.Services.AddTransient<ITeamSeedService, TeamSeedService>();
        builder.Services.AddTransient<ITeamPlayerSeedService, TeamPlayerSeedService>();
        builder.Services.AddTransient<IInviteDataService, InviteDataService>();
        builder.Services.AddTransient<ITeamPlayerInviteService, TeamPlayerInviteService>();
        builder.Services.AddTransient<ITeamPlayerInviteSeedService, TeamPlayerInviteSeedService>();

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
        builder.Services.AddTransient<IPlayerService, PlayerService>();
        builder.Services.AddTransient<ITeamService, TeamService>();

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();
        builder.Services.AddScoped<ITeamReference, TeamReference>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
        builder.Services.AddScoped<IAuthorizationHandler, OwnInviteHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnPlayerHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnTeamHandler>();
    }
}