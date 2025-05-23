using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Invite.Application.Interfaces.Team.General;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Messages.Commands.Invite.Team.Player;
using SFC.Team.Messages.Commands.Team;
using SFC.Team.Messages.Commands.Team.General;

namespace SFC.Invite.Infrastructure.Services.Team.General;
public class TeamSeedService(IConfiguration configuration, IBus bus) : ITeamSeedService
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IBus _bus = bus;

    public async Task SendRequireTeamsSeedAsync(CancellationToken cancellationToken = default)
    {
        RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

        RequireTeamsSeed command = new() { Initiator = settings.Exchanges.Invite.Key };

        await _bus.Send(command, cancellationToken)
                  .ConfigureAwait(false);
    }
}