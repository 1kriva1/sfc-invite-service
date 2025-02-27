﻿using SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges;

namespace SFC.Invite.Infrastructure.Settings.RabbitMq;
public class RabbitMqSettings
{
    public const string SectionKey = "RabbitMq";

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public RabbitMqRetrySettings Retry { get; set; } = default!;

    public RabbitMqExchangesSettings Exchanges { get; set; } = default!;
}

public class RabbitMqRetrySettings
{
    public ushort Limit { get; set; }

    public IEnumerable<ushort> Intervals { get; set; } = [];
}

#region Exchanges

public class RabbitMqExchangesSettings
{
    public ExchangeSetting<DataExchangeValue> Data { get; set; } = default!;

    public ExchangeSetting<IdentityExchangeValue> Identity { get; set; } = default!;

    public ExchangeSetting<InviteExchangeValue> Invite { get; set; } = default!;
    public ExchangeSetting<PlayerExchangeValue> Player { get; set; } = default!;
}

public class ExchangeSetting<T>
{
    public string Key { get; set; } = default!;

    public T Value { get; set; } = default!;
}

public class Exchange
{
    public string Name { get; set; } = default!;

    public string Type { get; set; } = default!;

    public string? RoutingKey { get; set; }
}

#endregion Exchanges
