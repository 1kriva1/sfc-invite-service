using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Common.Settings;
using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Infrastructure.Cache;
using SFC.Invite.Infrastructure.Services.Cache;

namespace SFC.Invite.Infrastructure.Extensions;
public static class CacheExtensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<CacheSettings>(configuration.GetSection(CacheSettings.SectionKey));
        services.AddScoped<ICache, RedisCache>();
        services.AddScoped<IRefreshCache, RefreshCacheService>();

        return services;
    }
}
