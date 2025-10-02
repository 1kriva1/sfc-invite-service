using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Commands.CreateRange;
public class CreateTeamPlayerInvitesCommandValidator : AbstractValidator<CreateTeamPlayerInvitesCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public CreateTeamPlayerInvitesCommandValidator(
        ITeamRepository teamRepository,
        IPlayerRepository playerRepository,
        ITeamPlayerInviteRepository teamPlayerInviteRepository,
        ITeamPlayerRepository teamPlayerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _teamPlayerInviteRepository = teamPlayerInviteRepository;
        _teamPlayerRepository = teamPlayerRepository;

        RuleForEach(p => p.Invites)
           .SetValidator(new TeamPlayerInviteValidator(
               _teamRepository, _playerRepository,
               _teamPlayerInviteRepository, _teamPlayerRepository));
    }
}

public class TeamPlayerInviteValidator : AbstractValidator<CreateTeamPlayerInvitesDto>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository;
    private readonly ITeamPlayerRepository _teamPlayerRepository;

    public TeamPlayerInviteValidator(
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
        RuleFor(p => p.TeamComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Comment");

        RuleFor(invite => invite)
            // team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithMessage(Localization.TeamNotFound)
            // player not found
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithMessage(Localization.PlayerNotFound)
            // player already in team
            .MustAsync(async (request, cancellation) => !await _teamPlayerRepository
            .AnyAsync(request.TeamId, request.PlayerId, TeamPlayerStatusEnum.Active).ConfigureAwait(false))
            .WithMessage(Localization.PlayerAlreadyInTeam)
            // invite already exist
            .MustAsync(async (invite, cancellation) => !await _teamPlayerInviteRepository
            .AnyAsync(invite.TeamId, invite.PlayerId, InviteStatusEnum.Actual).ConfigureAwait(false))
            .WithMessage(Localization.TeamPlayerInviteActiveAlreadyExist);
    }
}