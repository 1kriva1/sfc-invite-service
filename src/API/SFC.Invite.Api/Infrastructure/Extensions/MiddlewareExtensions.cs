using SFC.Invite.Api.Infrastructure.Middlewares;

namespace SFC.Invite.Api.Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
