namespace SFC.Invite.Application.Interfaces.Game.General;
public interface IGameSeedService
{
    Task SendRequireGamesSeedAsync(CancellationToken cancellationToken = default);
}