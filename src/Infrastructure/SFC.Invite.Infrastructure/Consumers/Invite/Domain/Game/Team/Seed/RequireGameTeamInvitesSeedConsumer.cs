using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Interfaces.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Messages.Commands.Invite.Game.Team;

namespace SFC.Invite.Infrastructure.Consumers.Invite.Domain.Game.Team.Seed;
public class RequireGameTeamInvitesSeedConsumer(
    ILogger<RequireGameTeamInvitesSeedConsumer> logger,
    IMapper mapper,
    IGameTeamInviteSeedService gameTeamInviteSeedService) : IConsumer<RequireGameTeamInvitesSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireGameTeamInvitesSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamInviteSeedService _gameTeamInviteSeedService = gameTeamInviteSeedService;

    public async Task Consume(ConsumeContext<RequireGameTeamInvitesSeed> context)
    {
        RequireGameTeamInvitesSeed message = context.Message;

        IEnumerable<GameTeamInvite> games = await _gameTeamInviteSeedService.GetSeedGameTeamInvitesAsync().ConfigureAwait(true);

        SeedGameTeamInvites command = _mapper.Map<SeedGameTeamInvites>(games)
                                               .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireGameTeamInvitesSeedDefinition : ConsumerDefinition<RequireGameTeamInvitesSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Invite.Value.Domain.Game.Team.Seed.RequireSeed; } }

    public RequireGameTeamInvitesSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.game.team.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireGameTeamInvitesSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}