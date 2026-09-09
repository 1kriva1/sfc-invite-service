using FluentValidation;

using SFC.Invite.Application.Features.Common.Validators.Common;
using SFC.Invite.Application.Features.Common.Validators.Team;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find;
public class GetGameTeamInvitesQueryValidator : AbstractValidator<GetGameTeamInvitesQuery>
{
    public GetGameTeamInvitesQueryValidator()
    {
        // pagination request filter
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGameTeamInvitesViewModel, GetGameTeamInvitesFilterDto>());

        // Team filter
        When(p => p?.Filter?.Team != null, () =>
        {
            RuleFor(command => command.Filter.Team!)
                .SetValidator(new TeamFilterValidator());
        });
    }
}