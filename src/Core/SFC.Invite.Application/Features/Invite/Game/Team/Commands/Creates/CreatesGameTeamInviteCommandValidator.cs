using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;
public class CreatesGameTeamInviteCommandValidator : AbstractValidator<CreatesGameTeamInviteCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository;
    private readonly IGameTeamRepository _gameTeamRepository;

    public CreatesGameTeamInviteCommandValidator(
        IGameRepository gameRepository,
        ITeamRepository teamRepository,
        IGameTeamInviteRepository gameTeamInviteRepository,
        IGameTeamRepository gameTeamRepository)
    {
        _gameRepository = gameRepository;
        _teamRepository = teamRepository;
        _gameTeamInviteRepository = gameTeamInviteRepository;
        _gameTeamRepository = gameTeamRepository;

        RuleForEach(p => p.Invites)
           .SetValidator(new GameTeamInviteValidator(
               _gameRepository, _teamRepository,
               _gameTeamInviteRepository, _gameTeamRepository));
    }
}

public class GameTeamInviteValidator : AbstractValidator<CreatesGameTeamInviteDto>
{
    private readonly IGameRepository _gameRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository;
    private readonly IGameTeamRepository _gameTeamRepository;

    public GameTeamInviteValidator(
        IGameRepository gameRepository,
        ITeamRepository teamRepository,
        IGameTeamInviteRepository gameTeamInviteRepository,
        IGameTeamRepository gameTeamRepository)
    {
        _gameRepository = gameRepository;
        _teamRepository = teamRepository;
        _gameTeamInviteRepository = gameTeamInviteRepository;
        _gameTeamRepository = gameTeamRepository;

        SetRulesForInvite();
    }

    private void SetRulesForInvite()
    {
        RuleFor(p => p.GameComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Comment");

        RuleFor(invite => invite)
            // Game not found
            .MustAsync(async (request, cancellation) => await _gameRepository.AnyAsync(request.GameId).ConfigureAwait(true))
            .WithMessage(Localization.GameNotFound)
            // Team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithMessage(Localization.TeamNotFound)
            // Team already in Game
            .MustAsync(async (request, cancellation) => !await _gameTeamRepository
            .AnyAsync(request.GameId, request.TeamId).ConfigureAwait(false))
            .WithMessage(Localization.TeamAlreadyInGame)
            // invite already exist
            .MustAsync(async (invite, cancellation) => !await _gameTeamInviteRepository
            .AnyAsync(invite.GameId, invite.TeamId, InviteStatusEnum.Actual).ConfigureAwait(false))
            .WithMessage(Localization.GameTeamInviteActiveAlreadyExist);
    }
}