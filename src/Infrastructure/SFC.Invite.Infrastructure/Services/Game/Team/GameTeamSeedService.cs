using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.Team.General;
using SFC.Invite.Application.Interfaces.Game.Team;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;

namespace SFC.Invite.Infrastructure.Services.Game.Team;
public class GameTeamSeedService(IConfiguration configuration, IBus bus) : IGameTeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGameTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGameTeamsSeed command = new() { Initiator = settings.Exchanges.Invite.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}