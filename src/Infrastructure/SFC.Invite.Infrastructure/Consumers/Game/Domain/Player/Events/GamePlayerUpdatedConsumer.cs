using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Game.Messages.Events.Game.Player;
using SFC.Invite.Application.Features.Game.Player.Commands.Update;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;

namespace SFC.Invite.Infrastructure.Consumers.Game.Domain.Player.Events;
public class GamePlayerUpdatedConsumer(
    IMapper mapper,
    ILogger<GamePlayerUpdatedConsumer> logger,
    ISender mediator) : IConsumer<GamePlayerUpdated>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<GamePlayerUpdatedConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<GamePlayerUpdated> context)
    {
        GamePlayerUpdated @event = context.Message;

        UpdateGamePlayerCommand command = _mapper.Map<UpdateGamePlayerCommand>(@event);

        await _mediator.Send(command)
                       .ConfigureAwait(false);
    }
}

public class GamePlayerUpdatedConsumerDefinition : ConsumerDefinition<GamePlayerUpdatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Game.Value.Domain.Player.Events.Updated; } }

    public GamePlayerUpdatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.game.player.updated.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<GamePlayerUpdatedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.game.player.updated"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}