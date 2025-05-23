using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;
public class UpdateTeamPlayerInviteCommandValidator : AbstractValidator<UpdateTeamPlayerInviteCommand>
{
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository;

    public UpdateTeamPlayerInviteCommandValidator(ITeamPlayerInviteRepository teamPlayerInviteRepository)
    {
        _teamPlayerInviteRepository = teamPlayerInviteRepository;

        SetRulesForInvite();
    }

    private void SetRulesForInvite()
    {
        RuleFor(invite => invite.Invite)
            .MustAsync((invite, cancellation) => IsInviteHasActualStatusAsync(invite))
            .WithException(new ConflictException(Localization.InviteAlreadyFinalized));

        When(p => p.Invite.Status == (int)InviteStatusEnum.Refused, () =>
        {
            RuleFor(p => p.Invite.PlayerComment!)
                .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
                .OverridePropertyName("Invite.Comment");
        });
    }

    private async Task<bool> IsInviteHasActualStatusAsync(UpdateTeamPlayerInviteDto invite)
    {
        TeamPlayerInvite? teamPlayerInvite = await _teamPlayerInviteRepository.GetByIdAsync(invite.Id).ConfigureAwait(true);
        return teamPlayerInvite is null || teamPlayerInvite.StatusId == (int)InviteStatusEnum.Actual;
    }
}