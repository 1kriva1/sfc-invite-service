using AutoMapper;

using MassTransit;

using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Invite.Game.Player;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;
using SFC.Invite.Messages.Events.Invite.Game.Player;

namespace SFC.Invite.Infrastructure.Services.Invite.Game.Player;
public class GamePlayerInviteSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    IGamePlayerInviteRepository gamePlayerInviteRepository,
    IGameRepository gameRepository) : IGamePlayerInviteSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;
    private readonly IGameRepository _gameRepository = gameRepository;

    #region Stub data

    private static readonly IEnumerable<(InviteStatusEnum, long)> Game_IDS =
    [
        (InviteStatusEnum.Accepted, 1),
        (InviteStatusEnum.Accepted, 2),
        (InviteStatusEnum.Accepted, 3),
        (InviteStatusEnum.Accepted, 4),
        (InviteStatusEnum.Accepted, 5),
        (InviteStatusEnum.Accepted, 6),
        (InviteStatusEnum.Accepted, 7),
        (InviteStatusEnum.Accepted, 8),
        (InviteStatusEnum.Canceled, 9),
        (InviteStatusEnum.Canceled, 10),
        (InviteStatusEnum.Canceled, 11),
        (InviteStatusEnum.Canceled, 12),
        (InviteStatusEnum.Refused, 13),
        (InviteStatusEnum.Refused, 14),
        (InviteStatusEnum.Refused, 15),
        (InviteStatusEnum.Refused, 16),
        (InviteStatusEnum.Actual, 17),
        (InviteStatusEnum.Actual, 18),
        (InviteStatusEnum.Actual, 19),
        (InviteStatusEnum.Actual, 20)
    ];
    private static readonly List<long> PLAYER_IDS = [20, 21, 22, 23, 24, 25];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<GamePlayerInvite>> GetSeedGamePlayerInvitesAsync()
    {
        return await _gamePlayerInviteRepository.GetByIdsAsync(Game_IDS.Select(item => item.Item2), PLAYER_IDS).ConfigureAwait(true);
    }

    public async Task SeedGamePlayerInvitesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<GamePlayerInvite> invites = await CreateSeedGamePlayerInvitesAsync().ConfigureAwait(true);

        GamePlayerInvite[] seedInvites = await _gamePlayerInviteRepository.AddRangeIfNotExistsAsync([.. invites]).ConfigureAwait(true);

        await PublishGamePlayerInvitesSeededEventAsync(seedInvites, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.GamePlayerInvite, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<GamePlayerInvite>> CreateSeedGamePlayerInvitesAsync()
    {
        List<GamePlayerInvite> result = [];

        foreach ((InviteStatusEnum, long) item in Game_IDS)
        {
            IEnumerable<GamePlayerInvite> part = await BuildGamePlayerInviteAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<GamePlayerInvite>> BuildGamePlayerInviteAsync(long gameId, InviteStatusEnum status)
    {
        GameEntity? game = await _gameRepository.GetByIdAsync(gameId).ConfigureAwait(true);

        Guid userId = game!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return PLAYER_IDS.Select(playerId => new GamePlayerInvite()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            GameId = gameId,
            PlayerId = playerId,
            StatusId = status,
            GameComment = "Seed invite",
            PlayerComment = status == InviteStatusEnum.Refused ? "Seed player comment" : null
        });
    }

    private Task PublishGamePlayerInvitesSeededEventAsync(IEnumerable<GamePlayerInvite> Games, CancellationToken cancellationToken = default)
    {
        GamePlayerInvitesSeeded @event = _mapper.Map<GamePlayerInvitesSeeded>(Games);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}