using SFC.Invite.Application.Common.Dto.Identity;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Identity.Commands.Create;
public class CreateUserCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateUser; }

    public UserDto User { get; set; } = null!;
}
