using SFC.Invite.Application.Common.Dto.Identity;
using SFC.Invite.Domain.Entities.Identity.General;

namespace SFC.Invite.Application.Interfaces.Reference;

/// <summary>
/// Identity user reference service.
/// </summary>
public interface IIdentityReference : IReference<User, Guid, UserDto> { }