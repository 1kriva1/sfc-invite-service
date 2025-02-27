using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Common.Settings;
using SFC.Invite.Application.Interfaces.Persistence.Repository;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
using SFC.Invite.Infrastructure.Persistence.Repositories.Player;
using SFC.Invite.Infrastructure.Persistence.Repositories;
using SFC.Invite.Infrastructure.Persistence.Repositories.Data;
using SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.Invite.Infrastructure.Persistence.Repositories.Invite;
using SFC.Invite.Infrastructure.Persistence.Repositories.Identity;
using SFC.Invite.Infrastructure.Persistence.Repositories.Metadata;

namespace SFC.Invite.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IMetadataRepository, MetadataRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IInviteRepository, InviteRepository>();

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
            services.AddScoped<FootballPositionRepository>();
            services.AddScoped<IFootballPositionRepository, FootballPositionCacheRepository>();
            services.AddScoped<GameStyleRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleCacheRepository>();
            services.AddScoped<StatCategoryRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryCacheRepository>();
            services.AddScoped<StatSkillRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillCacheRepository>();
            services.AddScoped<StatTypeRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeCacheRepository>();
            services.AddScoped<WorkingFootRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootCacheRepository>();
        }
        else
        {
            // data
            services.AddScoped<IFootballPositionRepository, FootballPositionRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootRepository>();
        }

        return services;
    }
}
