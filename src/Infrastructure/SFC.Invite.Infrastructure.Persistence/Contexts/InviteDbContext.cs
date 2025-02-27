using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Persistence.Context;
using SFC.Invite.Infrastructure.Persistence.Constants;

using SFC.Invite.Infrastructure.Persistence.Interceptors;

namespace SFC.Invite.Infrastructure.Persistence.Contexts;
public class InviteDbContext(
    IDateTimeService dateTimeService,
    IHostEnvironment hostEnvironment,
    DbContextOptions<InviteDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<InviteDbContext>(options, eventsInterceptor), IInviteDbContext
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IDateTimeService _dateTimeService = dateTimeService;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;

    public IQueryable<InviteEntity> Invites => Set<InviteEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.DefaultSchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // seed data
        //modelBuilder.SeedInviteData(_dateTimeService);

        // metadata
        MetadataDbContext.ApplyMetadataConfigurations(modelBuilder, _hostEnvironment.IsDevelopment());

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
