namespace SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges;
public class InviteExchangeValue
{
    public Exchange DataInit { get; set; } = default!;

    public Exchange DataRequire { get; set; } = default!;
}
