namespace SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges;
public class IdentityExchangeValue
{
    public Exchange UserCreated { get; set; } = default!;

    public Exchange UsersSeeded { get; set; } = default!;

    public Exchange SeedUsers { get; set; } = default!;

    public Exchange RequireUsersSeed { get; set; } = default!;
}
