using Microsoft.AspNetCore.Http;

using SFC.Invite.Application.Interfaces.Identity;
using SFC.Invite.Infrastructure.Extensions;

namespace SFC.Invite.Infrastructure.Services.Identity;
public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId() => _httpContextAccessor.GetUserId();
}
