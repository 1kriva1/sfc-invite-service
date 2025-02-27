namespace SFC.Invite.Infrastructure.Settings.RabbitMq.Exchanges;
public class PlayerExchangeValue
{
    public Exchange PlayerCreated { get; set; } = default!;

    public Exchange PlayerUpdated { get; set; } = default!;

    public Exchange PlayersSeeded { get; set; } = default!;

    public Exchange SeedPlayers { get; set; } = default!;

    public Exchange RequirePlayersSeed { get; set; } = default!;
}
