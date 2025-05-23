using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Invite.Application.Common.Settings;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Common;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common;
using SFC.Invite.Infrastructure.Persistence.Repositories.Data;
using SFC.Invite.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.Invite.Infrastructure.Persistence.Repositories.Identity;
using SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data;
using SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data.Cache;
using SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Repositories.Metadata;
using SFC.Invite.Infrastructure.Persistence.Repositories.Player;
using SFC.Invite.Infrastructure.Persistence.Repositories.Team.Data;
using SFC.Invite.Infrastructure.Persistence.Repositories.Team.Data.Cache;
using SFC.Invite.Infrastructure.Persistence.Repositories.Team.General;
using SFC.Invite.Infrastructure.Persistence.Repositories.Team.Player;

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
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITeamPlayerRepository, TeamPlayerRepository>();
        services.AddScoped<ITeamPlayerInviteRepository, TeamPlayerInviteRepository>();

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
            services.AddScoped<ShirtRepository>();
            services.AddScoped<IShirtRepository, ShirtCacheRepository>();

            // invite
            services.AddScoped<InviteStatusRepository>();
            services.AddScoped<IInviteStatusRepository, InviteStatusCacheRepository>();

            // team
            services.AddScoped<TeamPlayerStatusRepository>();
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusCacheRepository>();
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
            services.AddScoped<IShirtRepository, ShirtRepository>();

            // invite
            services.AddScoped<IInviteStatusRepository, InviteStatusRepository>();

            // team
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusRepository>();
        }

        return services;
    }
}