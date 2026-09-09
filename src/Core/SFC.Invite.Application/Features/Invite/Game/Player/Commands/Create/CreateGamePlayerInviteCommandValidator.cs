using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;
public class CreateGamePlayerInviteCommandValidator : AbstractValidator<CreateGamePlayerInviteCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository;
    private readonly IGamePlayerRepository _gamePlayerRepository;

    public CreateGamePlayerInviteCommandValidator(
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
        RuleFor(p => p.Invite.GameComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Invite.Comment");

        RuleFor(invite => invite.Invite)
            // Game not found
            .MustAsync(async (request, cancellation) => await _gameRepository.AnyAsync(request.GameId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.GameNotFound))
            // player not found
            .MustAsync(async (request, cancellation) => await _playerRepository.AnyAsync(request.PlayerId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.PlayerNotFound))
            // player already in Game
            .MustAsync(async (request, cancellation) => !await _gamePlayerRepository
                .AnyAsync(request.GameId, request.PlayerId).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.PlayerAlreadyInGame))
            // request already exist
            .MustAsync(async (invite, cancellation) => !await _gamePlayerInviteRepository
                .AnyAsync(invite.GameId, invite.PlayerId, InviteStatusEnum.Actual).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.GamePlayerInviteActiveAlreadyExist));
    }
}