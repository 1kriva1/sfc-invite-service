using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Extensions.Grpc;
using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Infrastructure.Services.Common;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Identity;
using SFC.Invite.Infrastructure.Services.Identity;
using SFC.Invite.Infrastructure.Services.Metadata;
using SFC.Invite.Application.Interfaces.Reference;
using SFC.Invite.Infrastructure.Services.Reference;
using SFC.Invite.Infrastructure.Services.Hosted;
using SFC.Invite.Application.Interfaces.Player;
using SFC.Invite.Infrastructure.Services.Player;

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

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
        builder.Services.AddTransient<IPlayerService, PlayerService>();

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
    }
}
