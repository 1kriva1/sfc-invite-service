using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Game.Messages.Commands.Game.Player;
using SFC.Invite.Application.Interfaces.Game.Player;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;

namespace SFC.Invite.Infrastructure.Services.Game.Player;
public class GamePlayerSeedService(IConfiguration configuration, IBus bus) : IGamePlayerSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireGamePlayersSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireGamePlayersSeed command = new() { Initiator = settings.Exchanges.Invite.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}