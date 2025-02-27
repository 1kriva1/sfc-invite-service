using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Common.Settings;

namespace SFC.Invite.Infrastructure.Extensions;
public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        CacheSettings settings = configuration.GetCacheSettings();

        return services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = $"{settings.InstanceName}:";
        });
    }
}
