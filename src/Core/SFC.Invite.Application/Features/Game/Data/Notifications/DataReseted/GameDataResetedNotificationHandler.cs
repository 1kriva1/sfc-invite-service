using MediatR;

using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Domain.Events.Game.Data;

namespace SFC.Invite.Application.Features.Game.Data.Notifications.DataReseted;
public class GameDataResetedNotificationHandler(IMetadataService metadataService)
    : INotificationHandler<GameDataResetedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;

    public async Task Handle(GameDataResetedEvent notification, CancellationToken cancellationToken)
    {
        await _metadataService.CompleteAsync(MetadataServiceEnum.Game, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }
}