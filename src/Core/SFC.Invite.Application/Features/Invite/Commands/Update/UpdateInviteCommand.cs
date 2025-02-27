using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;

namespace SFC.Invite.Application.Features.Invite.Commands.Update;
public class UpdateInviteCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateInvite; }

    public long InviteId { get; set; }

    public required UpdateInviteDto Invite { get; set; }

    public UpdateInviteCommand SetInviteId(long id)
    {
        InviteId = id;
        return this;
    }
}
