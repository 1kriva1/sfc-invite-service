using SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges;
public class InviteExchangeValue
{
    public DataExchange<InviteDataDependentExchange> Data { get; set; } = default!;

    public InviteDomainExchange Domain { get; set; } = default!;
}

public class InviteDataDependentExchange
{
    public DataDependentExchange Data { get; set; } = default!;

    public DataDependentExchange Team { get; set; } = default!;
}

public class InviteDomainExchange
{
    public InviteTeamDomainExchange Team { get; set; } = default!;

    public InviteGameDomainExchange Game { get; set; } = default!;
}

public class InviteTeamDomainExchange
{
    public DomainExchange<InviteTeamPlayerDomainEventsExchange> Player { get; set; } = default!;
}

public class InviteGameDomainExchange
{
}

public class InviteTeamPlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class InviteGamePlayerDomainEventsExchange
{
}

public class InviteGameTeamDomainEventsExchange
{
}