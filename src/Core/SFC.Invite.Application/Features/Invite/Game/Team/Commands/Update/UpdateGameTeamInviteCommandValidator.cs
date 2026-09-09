using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;
public class UpdateGameTeamInviteCommandValidator : AbstractValidator<UpdateGameTeamInviteCommand>
{
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository;

    public UpdateGameTeamInviteCommandValidator(IGameTeamInviteRepository gameTeamInviteRepository)
    {
        _gameTeamInviteRepository = gameTeamInviteRepository;

        SetRulesForInvite();
    }

    private void SetRulesForInvite()
    {
        RuleFor(invite => invite.Invite)
            .MustAsync((invite, cancellation) => IsInviteHasActualStatusAsync(invite))
            .WithException(new ConflictException(Localization.InviteAlreadyFinalized));

        When(p => p.Invite.Status == (int)InviteStatusEnum.Refused, () =>
        {
            RuleFor(p => p.Invite.TeamComment!)
                .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
                .OverridePropertyName("Invite.Comment");
        });
    }

    private async Task<bool> IsInviteHasActualStatusAsync(UpdateGameTeamInviteDto invite)
    {
        GameTeamInvite? gameTeamInvite = await _gameTeamInviteRepository.GetByIdAsync(invite.Id).ConfigureAwait(true);
        return gameTeamInvite is null || gameTeamInvite.StatusId == (int)InviteStatusEnum.Actual;
    }
}