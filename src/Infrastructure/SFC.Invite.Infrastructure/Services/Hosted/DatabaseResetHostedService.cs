﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Services.Hosted;
public class DatabaseResetHostedService(
    ILogger<DatabaseResetHostedService> logger,
    IServiceProvider services,
    IHostEnvironment hostEnvironment) : BaseInitializationService(logger)
{
    private readonly IServiceProvider _services = services;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        EventId eventId = new((int)RequestId.DatabaseReset, Enum.GetName(RequestId.DatabaseReset));
        Action<ILogger, Exception?> logStartExecution = LoggerMessage.Define(LogLevel.Information, eventId,
            "Data Initialization Hosted Service running.");
        logStartExecution(Logger, null);

        using IServiceScope scope = _services.CreateScope();

        InviteDbContext context = scope.ServiceProvider.GetRequiredService<InviteDbContext>();

        if (_hostEnvironment.IsDevelopment())
        {
            await context.Database.EnsureDeletedAsync(cancellationToken)
                                  .ConfigureAwait(false);
        }

        await context.Database.EnsureCreatedAsync(cancellationToken)
                              .ConfigureAwait(false);
    }
}
