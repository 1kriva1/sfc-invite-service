using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
public class CreateTeamPlayerInviteCommandValidator : AbstractValidator<CreateTeamPlayerInviteCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public CreateTeamPlayerInviteCommandValidator(
        ITeamRepository teamRepository,
        IPlayerRepository playerRepository,
        ITeamPlayerInviteRepository teamPlayerInviteRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _teamPlayerInviteRepository = teamPlayerInviteRepository;
        _teamPlayerRepository = teamPlayerRepository;

        SetRulesForInvite();
    }

    private void SetRulesForInvite()
    {
        RuleFor(p => p.Invite.TeamComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Invite.Comment");

        RuleFor(invite => invite.Invite)
            // team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.TeamNotFound))
            // player not found
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.PlayerNotFound))
            // player already in team
            .MustAsync(async (request, cancellation) => !await _teamPlayerRepository
                .AnyAsync(request.TeamId, request.PlayerId, TeamPlayerStatusEnum.Active).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.PlayerAlreadyInTeam))
            // request already exist
            .MustAsync(async (invite, cancellation) => !await _teamPlayerInviteRepository
                .AnyAsync(invite.TeamId, invite.PlayerId, InviteStatusEnum.Actual).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.TeamPlayerInviteActiveAlreadyExist));
    }
}