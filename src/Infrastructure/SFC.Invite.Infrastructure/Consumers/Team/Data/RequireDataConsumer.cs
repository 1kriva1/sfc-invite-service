using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Data.Models;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Invite.Data;

namespace SFC.Invite.Infrastructure.Consumers.Team.Data;

public class RequireDataConsumer(IMapper mapper, IInviteDataService inviteDataService)
    : IConsumer<RequireData>
{
    private readonly IMapper _mapper = mapper;
    private readonly IInviteDataService _inviteDataService = inviteDataService;

    public async Task Consume(ConsumeContext<RequireData> context)
    {
        GetTeamDataModel model = await _inviteDataService.GetTeamDataAsync().ConfigureAwait(true);

        InitializeData command = _mapper.BuildInitializeDataCommand(model);

        await context.Send(command).ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<RequireDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Team.Value.Data.Dependent.Invite.RequireInitialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.team.data.initialize.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireDataConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.invite.data.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}