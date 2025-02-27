using MediatR;

using Microsoft.Extensions.Hosting;

using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Domain.Events.Identity;

namespace SFC.Invite.Application.Features.Identity.Notifications.CreateUsers;
public class UsersCreatedNotificationHandler(
    IMetadataService metadataService,
    IHostEnvironment hostEnvironment) : INotificationHandler<UsersCreatedEvent>
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task Handle(UsersCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (_hostEnvironment.IsDevelopment())
        {
            await _metadataService.CompleteAsync(MetadataServiceEnum.Identity, MetadataTypeEnum.Seed).ConfigureAwait(false);

            if (await _metadataService.IsCompletedAsync(MetadataServiceEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(true))
            {

            }
        }
    }
}
