using FluentValidation;

using SFC.Invite.Application.Features.Invite.Commands.Common.Validators;

namespace SFC.Invite.Application.Features.Invite.Commands.Create;
public class CreateInviteCommandValidator : AbstractValidator<CreateInviteCommand>
{
    public CreateInviteCommandValidator()
    {
        RuleFor(command => command.Invite)
            .SetValidator(new InviteValidator<CreateInviteDto>());
    }
}
