using FluentValidation;

using SFC.Invite.Application.Features.Common.Validators;
using SFC.Invite.Application.Features.Common.Validators.Common;
using SFC.Invite.Application.Features.Invite.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Queries.Find;
public class GetInvitesQueryValidator : AbstractValidator<GetInvitesQuery>
{
    public GetInvitesQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetInvitesViewModel, GetInvitesFilterDto>());
    }
}