using FluentValidation;

using SFC.Invite.Application.Common.Constants;
using SFC.Invite.Application.Common.Exceptions;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;
public class CreateGameTeamInviteCommandValidator : AbstractValidator<CreateGameTeamInviteCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository;
    private readonly IGameTeamRepository _gameTeamRepository;

    public CreateGameTeamInviteCommandValidator(
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
        RuleFor(p => p.Invite.GameComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Invite.Comment");

        RuleFor(invite => invite.Invite)
            // Game not found
            .MustAsync(async (request, cancellation) => await _gameRepository.AnyAsync(request.GameId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.GameNotFound))
            // Team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.TeamNotFound))
            // Team already in Game
            .MustAsync(async (request, cancellation) => !await _gameTeamRepository
                .AnyAsync(request.GameId, request.TeamId).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.TeamAlreadyInGame))
            // request already exist
            .MustAsync(async (invite, cancellation) => !await _gameTeamInviteRepository
                .AnyAsync(invite.GameId, invite.TeamId, InviteStatusEnum.Actual).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.GameTeamInviteActiveAlreadyExist));
    }
}