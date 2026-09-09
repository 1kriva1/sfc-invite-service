using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;
public class CreatesGamePlayerInviteCommandValidator : AbstractValidator<CreatesGamePlayerInviteCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository;
    private readonly IGamePlayerRepository _gamePlayerRepository;

    public CreatesGamePlayerInviteCommandValidator(
        IGameRepository gameRepository,
        IPlayerRepository playerRepository,
        IGamePlayerInviteRepository gamePlayerInviteRepository,
        IGamePlayerRepository gamePlayerRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
        _gamePlayerInviteRepository = gamePlayerInviteRepository;
        _gamePlayerRepository = gamePlayerRepository;

        RuleForEach(p => p.Invites)
           .SetValidator(new GamePlayerInviteValidator(
               _gameRepository, _playerRepository,
               _gamePlayerInviteRepository, _gamePlayerRepository));
    }
}

public class GamePlayerInviteValidator : AbstractValidator<CreatesGamePlayerInviteDto>
{
    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository;
    private readonly IGamePlayerRepository _gamePlayerRepository;

    public GamePlayerInviteValidator(
        IGameRepository gameRepository,
        IPlayerRepository playerRepository,
        IGamePlayerInviteRepository gamePlayerInviteRepository,
        IGamePlayerRepository gamePlayerRepository)
    {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
        _gamePlayerInviteRepository = gamePlayerInviteRepository;
        _gamePlayerRepository = gamePlayerRepository;

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
            // player not found
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithMessage(Localization.PlayerNotFound)
            // player already in Game
            .MustAsync(async (request, cancellation) => !await _gamePlayerRepository
            .AnyAsync(request.GameId, request.PlayerId).ConfigureAwait(false))
            .WithMessage(Localization.PlayerAlreadyInGame)
            // invite already exist
            .MustAsync(async (invite, cancellation) => !await _gamePlayerInviteRepository
            .AnyAsync(invite.GameId, invite.PlayerId, InviteStatusEnum.Actual).ConfigureAwait(false))
            .WithMessage(Localization.GamePlayerInviteActiveAlreadyExist);
    }
}