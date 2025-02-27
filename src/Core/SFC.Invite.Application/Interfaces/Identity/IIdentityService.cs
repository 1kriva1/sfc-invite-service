using SFC.Invite.Application.Common.Dto.Identity;

namespace SFC.Invite.Application.Interfaces.Identity;

/// <summary>
/// Adapter to Identity service (GRPC).
/// </summary>
public interface IIdentityService
{
    Task<UserDto?> GetUserAsync(Guid id, CancellationToken cancellationToken = default);
}
