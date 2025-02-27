using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Common.Dto.Base;
using SFC.Invite.Domain.Entities.Identity;

namespace SFC.Invite.Application.Common.Dto.Identity;
public class UserDto : BaseAuditableDto, IMapTo<User>
{
    public Guid Id { get; set; }
}