using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Interfaces.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Messages.Commands.Invite.Game.Player;

namespace SFC.Invite.Infrastructure.Consumers.Invite.Domain.Game.Player.Seed;
public class RequireGamePlayerInvitesSeedConsumer(
    ILogger<RequireGamePlayerInvitesSeedConsumer> logger,
    IMapper mapper,
    IGamePlayerInviteSeedService gamePlayerInviteSeedService) : IConsumer<RequireGamePlayerInvitesSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireGamePlayerInvitesSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerInviteSeedService _gamePlayerInviteSeedService = gamePlayerInviteSeedService;

    public async Task Consume(ConsumeContext<RequireGamePlayerInvitesSeed> context)
    {
        RequireGamePlayerInvitesSeed message = context.Message;

        IEnumerable<GamePlayerInvite> games = await _gamePlayerInviteSeedService.GetSeedGamePlayerInvitesAsync().ConfigureAwait(true);

        SeedGamePlayerInvites command = _mapper.Map<SeedGamePlayerInvites>(games)
                                               .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireGamePlayerInvitesSeedDefinition : ConsumerDefinition<RequireGamePlayerInvitesSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Invite.Value.Domain.Game.Player.Seed.RequireSeed; } }

    public RequireGamePlayerInvitesSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.game.player.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireGamePlayerInvitesSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.game.games.seed.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}