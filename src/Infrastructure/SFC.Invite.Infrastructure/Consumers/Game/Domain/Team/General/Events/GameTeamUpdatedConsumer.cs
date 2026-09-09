using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.Team.General;
using SFC.Invite.Application.Features.Game.Team.Commands.Update;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;

namespace SFC.Invite.Infrastructure.Consumers.Game.Domain.Team.General.Events;
public class GameTeamUpdatedConsumer(
    IMapper mapper,
    ILogger<GameTeamUpdatedConsumer> logger,
    ISender mediator) : IConsumer<GameTeamUpdated>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GameTeamUpdatedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GameTeamUpdated> context)
    {
        GameTeamUpdated @event = context.Message;

        UpdateGameTeamCommand command = _mapper.Map<UpdateGameTeamCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class GameTeamUpdatedConsumerDefinition : ConsumerDefinition<GameTeamUpdatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Team.Team.Events.Updated; } }

    public GameTeamUpdatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.game.team.team.updated.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GameTeamUpdatedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}