using SFC.Invite.Domain.Entities.Identity;

namespace SFC.Invite.Application.Interfaces.Persistence.Context;

/// <summary>
/// Identity service related entities.
/// </summary>
public interface IIdentityDbContext : IDbContext
{
    IQueryable<User> Users { get; }
}
