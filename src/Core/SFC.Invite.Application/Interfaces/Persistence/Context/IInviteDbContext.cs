namespace SFC.Invite.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface IInviteDbContext : IDbContext
{
    IQueryable<InviteEntity> Invites { get; }
}
