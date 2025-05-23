using FluentValidation;

using SFC.Invite.Application.Features.Common.Validators.Common;
using SFC.Invite.Application.Features.Common.Validators.Player;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
public class GetTeamPlayerInvitesQueryValidator : AbstractValidator<GetTeamPlayerInvitesQuery>
{
    public GetTeamPlayerInvitesQueryValidator()
    {
        // pagination request filter
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetTeamPlayerInvitesViewModel, GetTeamPlayerInvitesFilterDto>());

        // player filter
        When(p => p?.Filter?.Player != null, () =>
        {
            RuleFor(command => command.Filter.Player!)
                .SetValidator(new PlayerFilterValidator());
        });
    }
}