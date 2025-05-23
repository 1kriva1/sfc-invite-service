using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.Extensions.Configuration;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
using SFC.Invite.Application.Features.Player.Commands.Update;
using SFC.Invite.Application.Features.Player.Commands.Create;
using SFC.Player.Messages.Events.Player.General;

namespace SFC.Invite.Infrastructure.Consumers.Player.Domain.Player.Events;
public class PlayerUpdatedConsumer(
    IMapper mapper,
    ISender mediator,
    IPlayerRepository playerRepository) : IConsumer<PlayerUpdated>
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;
    private readonly IPlayerRepository _playerRepository = playerRepository;

    public async Task Consume(ConsumeContext<PlayerUpdated> context)
    {
        PlayerUpdated @event = context.Message;

        bool playerExist = await _playerRepository.AnyAsync(@event.Player.Id)
                                                  .ConfigureAwait(true);

        if (playerExist)
            await UpdatePlayerAsync(@event).ConfigureAwait(false);
        else
            await CreatePlayerAsync(@event).ConfigureAwait(false);
    }

    private Task UpdatePlayerAsync(PlayerUpdated @event)
    {
        UpdatePlayerCommand command = _mapper.Map<UpdatePlayerCommand>(@event);
        return _mediator.Send(command);
    }

    private Task CreatePlayerAsync(PlayerUpdated @event)
    {
        CreatePlayerCommand command = _mapper.Map<CreatePlayerCommand>(@event);
        return _mediator.Send(command);
    }
}

public class PlayerUpdatedConsumerDefinition : ConsumerDefinition<PlayerUpdatedConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Player.Value.Domain.Player.Events.Updated; } }

    public PlayerUpdatedConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.player.updated.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<PlayerUpdatedConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.player.updated"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}
