using SFC.Invite.Application.Interfaces.Persistence.Context;

namespace SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IInviteRepository : IRepository<InviteEntity, IInviteDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);
}
