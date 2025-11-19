using SFC.Invite.Api.Services;

namespace SFC.Invite.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        app.MapGrpcService<InviteDataService>();
        app.MapGrpcService<TeamPlayerInviteService>();

        return app;
    }
}