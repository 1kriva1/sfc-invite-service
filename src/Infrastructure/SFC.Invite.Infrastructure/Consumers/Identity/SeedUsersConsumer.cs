using AutoMapper;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Features.Identity.Commands.CreateRange;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings.RabbitMq;
using SFC.Identity.Messages.Commands;

using Exchange = SFC.Invite.Infrastructure.Settings.RabbitMq.Exchange;

namespace SFC.Invite.Infrastructure.Consumers.Identity;
public class SeedUsersConsumer(
    IMapper mapper,
    IWebHostEnvironment environment,
    ILogger<SeedUsersConsumer> logger,
    ISender mediator,
    IUserRepository userRepository) : IConsumer<SeedUsers>
{
#pragma warning disable CA1823 // Avoid unused private fields
    private readonly IMapper _mapper = mapper;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly ILogger<SeedUsersConsumer> _logger = logger;
    private readonly ISender _mediator = mediator;
    private readonly IUserRepository _userRepository = userRepository;
#pragma warning restore CA1823 // Avoid unused private fields

    public async Task Consume(ConsumeContext<SeedUsers> context)
    {
        if (_environment.IsDevelopment())
        {
            SeedUsers message = context.Message;

            CreateUsersCommand command = _mapper.Map<CreateUsersCommand>(message.Users);

            await _mediator.Send(command)
                           .ConfigureAwait(false);
        }
    }
}

public class SeedUsersConsumerDefinition : ConsumerDefinition<SeedUsersConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Exchange Exchange { get { return _settings.Exchanges.Identity.Value.SeedUsers; } }

    public SeedUsersConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.invite.identity.users.seed.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SeedUsersConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.invite.identity.users.seed"
            rmq.Bind(Exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = _settings.Exchanges.Invite.Key.BuildExchangeRoutingKey(_settings.Exchanges.Identity.Key);
                x.ExchangeType = Exchange.Type;
            });
        }
    }
}
