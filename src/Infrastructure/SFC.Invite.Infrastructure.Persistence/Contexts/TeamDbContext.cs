﻿using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Team.Data;
using SFC.Invite.Domain.Entities.Team.General;
using SFC.Invite.Domain.Entities.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Configurations.Team.Data;
using SFC.Invite.Infrastructure.Persistence.Configurations.Team.General;
using SFC.Invite.Infrastructure.Persistence.Configurations.Team.Player;
using SFC.Invite.Infrastructure.Persistence.Constants;
using SFC.Invite.Infrastructure.Persistence.Interceptors;

namespace SFC.Invite.Infrastructure.Persistence.Contexts;
public class TeamDbContext(
    DbContextOptions<TeamDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<TeamDbContext>(options, eventsInterceptor), ITeamDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;

    #region General

    public IQueryable<TeamEntity> Teams => Set<TeamEntity>();

    public IQueryable<TeamGeneralProfile> GeneralProfiles => Set<TeamGeneralProfile>();

    public IQueryable<TeamFinancialProfile> FinancialProfiles => Set<TeamFinancialProfile>();

    public IQueryable<TeamAvailability> Availability => Set<TeamAvailability>();

    public IQueryable<TeamTag> Tags => Set<TeamTag>();

    public IQueryable<TeamShirt> Shirts => Set<TeamShirt>();

    public IQueryable<TeamLogo> Logos => Set<TeamLogo>();

    public IQueryable<TeamPlayer> TeamPlayers => Set<TeamPlayer>();

    public IQueryable<TeamPlayerInvite> TeamPlayerInvites => Set<TeamPlayerInvite>();

    #endregion General

    #region Data

    public IQueryable<TeamPlayerStatus> TeamPlayerStatuses => Set<TeamPlayerStatus>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.TeamSchemaName);

        // data
        DataDbContext.ApplyDataConfigurations(modelBuilder);

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        // player
        PlayerDbContext.ApplyPlayerConfigurations(modelBuilder);

        // team
        ApplyTeamConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public static void ApplyTeamConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeamPlayerStatusConfiguration());

        modelBuilder.ApplyConfiguration(new TeamAvailabilityConfiguration());

        modelBuilder.ApplyConfiguration(new TeamConfiguration());

        modelBuilder.ApplyConfiguration(new TeamFinancialProfileConfiguration());

        modelBuilder.ApplyConfiguration(new TeamGeneralProfileConfiguration());

        modelBuilder.ApplyConfiguration(new TeamLogoConfiguration());

        modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());

        modelBuilder.ApplyConfiguration(new TeamShirtConfiguration());

        modelBuilder.ApplyConfiguration(new TeamTagConfiguration());
    }
}