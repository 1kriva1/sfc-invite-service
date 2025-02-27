using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Common.Dto;

namespace SFC.Invite.Application.Features.Invite.Commands.Create;
public class CreateInviteCommand : Request<CreateInviteViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateInvite; }

    public CreateInviteDto Invite { get; set; } = null!;
}
