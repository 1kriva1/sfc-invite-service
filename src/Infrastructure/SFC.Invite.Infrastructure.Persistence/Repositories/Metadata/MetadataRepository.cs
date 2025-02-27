using Microsoft.EntityFrameworkCore;

using SFC.Invite.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Metadata;
public class MetadataRepository(MetadataDbContext context)
    : Repository<MetadataEntity, MetadataDbContext, int>(context), IMetadataRepository
{
    public Task<MetadataEntity?> GetByIdAsync(MetadataServiceEnum service, MetadataTypeEnum type)
    {
        return Context.Metadata.FirstOrDefaultAsync(metadata => metadata.Service == service && metadata.Type == type);
    }
}