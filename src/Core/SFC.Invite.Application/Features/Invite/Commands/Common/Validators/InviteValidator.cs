using FluentValidation;

using SFC.Invite.Application.Features.Invite.Common.Dto;

namespace SFC.Invite.Application.Features.Invite.Commands.Common.Validators;
public class InviteValidator<T> : AbstractValidator<T> where T : BaseInviteDto
{
    public InviteValidator()
    {

    }
}
