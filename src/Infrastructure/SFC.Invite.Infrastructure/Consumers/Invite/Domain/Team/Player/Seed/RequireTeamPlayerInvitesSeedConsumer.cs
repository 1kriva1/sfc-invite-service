using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Messages.Commands.Invite.Team.Player;

namespace SFC.Invite.Infrastructure.Consumers.Invite.Domain.Team.Player.Seed;
public class RequireTeamPlayerInvitesSeedConsumer(
    ILogger<RequireTeamPlayerInvitesSeedConsumer> logger,
    IMapper mapper,
    ITeamPlayerInviteSeedService teamPlayerInviteSeedService) : IConsumer<RequireTeamPlayerInvitesSeed>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<RequireTeamPlayerInvitesSeedConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ITeamPlayerInviteSeedService _teamPlayerInviteSeedService = teamPlayerInviteSeedService;

    public async Task Consume(ConsumeContext<RequireTeamPlayerInvitesSeed> context)
    {
        RequireTeamPlayerInvitesSeed message = context.Message;

        IEnumerable<TeamPlayerInvite> teams = await _teamPlayerInviteSeedService.GetSeedTeamPlayerInvitesAsync().ConfigureAwait(true);

        SeedTeamPlayerInvites command = _mapper.Map<SeedTeamPlayerInvites>(teams)
                                               .SetCommandInitiator(message.Initiator);

        await context.Publish(command).ConfigureAwait(false);
    }
}

public class RequireTeamPlayerInvitesSeedDefinition : ConsumerDefinition<RequireTeamPlayerInvitesSeedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Invite.Value.Domain.Team.Player.Seed.RequireSeed; } }

    public RequireTeamPlayerInvitesSeedDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.team.player.seed.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireTeamPlayerInvitesSeedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.team.teams.seed.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}