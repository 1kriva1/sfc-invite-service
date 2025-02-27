using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SFC.Player.Messages.Events;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
using SFC.Invite.Application.Features.Player.Commands.CreateRange;

namespace SFC.Invite.Infrastructure.Consumers.Player;
public class PlayersSeededConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<PlayersSeededConsumer> logger,
    ISender mediator,
    IMetadataService metadataService,
    IPlayerRepository playerRepository) : IConsumer<PlayersSeeded>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<PlayersSeededConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IPlayerRepository _playerRepository = playerRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<PlayersSeeded> context)
    {
        if (_environment.IsDevelopment())
        {
            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(true) &&
                await _metadataService.IsCompletedAsync(MetadataServiceEnum.Identity, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                PlayersSeeded @event = context.Message;

                CreatePlayersCommand command = _mapper.Map<CreatePlayersCommand>(@event.Players);

                await _mediator.Send(command)
                               .ConfigureAwait(false);
            }
        }
    }
}

public class PlayersSeededConsumerDefinition : ConsumerDefinition<PlayersSeededConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Player.Value.PlayersSeeded; } }

    public PlayersSeededConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.player.players.seeded.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<PlayersSeededConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.player.players.seeded"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}
