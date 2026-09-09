using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;
public class UpdateGamePlayerInviteCommandValidator : AbstractValidator<UpdateGamePlayerInviteCommand>
{
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository;

    public UpdateGamePlayerInviteCommandValidator(IGamePlayerInviteRepository gamePlayerInviteRepository)
    {
        _gamePlayerInviteRepository = gamePlayerInviteRepository;

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

    private async Task<bool> IsInviteHasActualStatusAsync(UpdateGamePlayerInviteDto invite)
    {
        GamePlayerInvite? GamePlayerInvite = await _gamePlayerInviteRepository.GetByIdAsync(invite.Id).ConfigureAwait(true);
        return GamePlayerInvite is null || GamePlayerInvite.StatusId == (int)InviteStatusEnum.Actual;
    }
}