using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Metadata;

namespace SFC.Invite.Infrastructure.Services.Metadata;
public class MetadataService(IMetadataRepository metadataRepository) : IMetadataService
{
    private readonly IMetadataRepository _metadataRepository = metadataRepository;

    public async Task CompleteAsync(MetadataServiceEnum service, MetadataTypeEnum type)
    {
        MetadataEntity? metadata = await _metadataRepository.GetByIdAsync(service, type).ConfigureAwait(true);

        if (metadata is not null)
        {
            metadata.State = MetadataStateEnum.Done;
            await _metadataRepository.UpdateAsync(metadata).ConfigureAwait(false);
        }
    }

    public async Task<bool> IsCompletedAsync(MetadataServiceEnum service, MetadataTypeEnum type)
    {
        MetadataEntity? metadata = await _metadataRepository.GetByIdAsync(service, type).ConfigureAwait(true);
        return metadata?.State == MetadataStateEnum.Done;
    }
}
