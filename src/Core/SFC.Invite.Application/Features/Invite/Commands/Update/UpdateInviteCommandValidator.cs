using FluentValidation;

using SFC.Invite.Application.Features.Invite.Commands.Common.Validators;

namespace SFC.Invite.Application.Features.Invite.Commands.Update;
public class UpdateInviteCommandValidator : AbstractValidator<UpdateInviteCommand>
{
    public UpdateInviteCommandValidator()
    {
        RuleFor(command => command.Invite).SetValidator(new InviteValidator<UpdateInviteDto>());
    }
}
