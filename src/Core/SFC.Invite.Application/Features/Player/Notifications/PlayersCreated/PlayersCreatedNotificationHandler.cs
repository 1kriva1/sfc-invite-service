using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Team.General;
using SFC.Invite.Domain.Events.Player;

namespace SFC.Invite.Application.Features.Player.Notifications.PlayersCreated;
public class PlayersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment,
    ITeamSeedService teamSeedService) : INotificationHandler<PlayersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;
    private readonly ITeamSeedService _teamSeedService = teamSeedService;

    public async Task Handle(PlayersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Player, MetadataDomainEnum.Player, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (!await _metadataService.IsCompletedAsync(MetadataServiceEnum.Team, MetadataDomainEnum.Team, MetadataTypeEnum.Seed).ConfigureAwait(true))
            {
                await _teamSeedService.SendRequireTeamsSeedAsync(cancellationToken)
                                      .ConfigureAwait(false);
            }
        }
    }
}