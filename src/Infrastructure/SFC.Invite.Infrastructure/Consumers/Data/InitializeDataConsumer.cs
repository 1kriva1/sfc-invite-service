﻿using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Features.Data.Commands.Reset;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Messages.Commands;

namespace SFC.Invite.Infrastructure.Consumers.Data;
public class InitializeDataConsumer(
    IMapper mapper,
    ILogger<InitializeDataConsumer> logger,
    ISender mediator) : IConsumer<InitializeData>
{
    private readonly IMapper _mapper = mapper;
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly ILogger<InitializeDataConsumer> _logger = logger;
#pragma warning restore CA1823 // Avoid unused private fields
    private readonly ISender _mediator = mediator;

    public async Task Consume(ConsumeContext<InitializeData> context)
    {
        InitializeData message = context.Message;

        ResetDataCommand command = _mapper.Map<ResetDataCommand>(message);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<InitializeDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Invite.Value.DataInit; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.data.initialize.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<InitializeDataConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.invite.data.init"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}
