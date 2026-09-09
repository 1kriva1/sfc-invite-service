using FluentValidation;

using SFC.Invite.Application.Features.Common.Validators.Common;
using SFC.Invite.Application.Features.Common.Validators.Player;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;
public class GetGamePlayerInvitesQueryValidator : AbstractValidator<GetGamePlayerInvitesQuery>
{
    public GetGamePlayerInvitesQueryValidator()
    {
        // pagination request filter
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGamePlayerInvitesViewModel, GetGamePlayerInvitesFilterDto>());

        // player filter
        When(p => p?.Filter?.Player != null, () =>
        {
            RuleFor(command => command.Filter.Player!)
                .SetValidator(new PlayerFilterValidator());
        });
    }
}