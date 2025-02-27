using SFC.Invite.Application.Common.Dto.Identity;
using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateUsers; }

    public IEnumerable<UserDto> Users { get; set; } = null!;
}
