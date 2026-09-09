using AutoMapper;

using MassTransit;

using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Invite.Game.Team;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;
using SFC.Invite.Messages.Events.Invite.Game.Team;

namespace SFC.Invite.Infrastructure.Services.Invite.Game.Team;
public class GameTeamInviteSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    IGameTeamInviteRepository gameTeamInviteRepository,
    IGameRepository gameRepository) : IGameTeamInviteSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;
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
    private static readonly List<long> Team_IDS = [20, 21, 22, 23, 24, 25];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<GameTeamInvite>> GetSeedGameTeamInvitesAsync()
    {
        return await _gameTeamInviteRepository.GetByIdsAsync(Game_IDS.Select(item => item.Item2), Team_IDS).ConfigureAwait(true);
    }

    public async Task SeedGameTeamInvitesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<GameTeamInvite> invites = await CreateSeedGameTeamInvitesAsync().ConfigureAwait(true);

        GameTeamInvite[] seedInvites = await _gameTeamInviteRepository.AddRangeIfNotExistsAsync([.. invites]).ConfigureAwait(true);

        await PublishGameTeamInvitesSeededEventAsync(seedInvites, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.GameTeamInvite, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<GameTeamInvite>> CreateSeedGameTeamInvitesAsync()
    {
        List<GameTeamInvite> result = [];

        foreach ((InviteStatusEnum, long) item in Game_IDS)
        {
            IEnumerable<GameTeamInvite> part = await BuildGameTeamInviteAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<GameTeamInvite>> BuildGameTeamInviteAsync(long gameId, InviteStatusEnum status)
    {
        GameEntity? game = await _gameRepository.GetByIdAsync(gameId).ConfigureAwait(true);

        Guid userId = game!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return Team_IDS.Select(teamId => new GameTeamInvite()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            GameId = gameId,
            TeamId = teamId,
            StatusId = status,
            GameComment = "Seed invite",
            TeamComment = status == InviteStatusEnum.Refused ? "Seed Team comment" : null
        });
    }

    private Task PublishGameTeamInvitesSeededEventAsync(IEnumerable<GameTeamInvite> Games, CancellationToken cancellationToken = default)
    {
        GameTeamInvitesSeeded @event = _mapper.Map<GameTeamInvitesSeeded>(Games);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}