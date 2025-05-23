using AutoMapper;

using MassTransit;

using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Metadata;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Messages.Events.Invite.Team.Player;

namespace SFC.Invite.Infrastructure.Services.Invite.Team.Player;
public class TeamPlayerInviteSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    ITeamPlayerInviteRepository teamPlayerInviteRepository,
    ITeamRepository teamRepository) : ITeamPlayerInviteSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;
    private readonly ITeamRepository _teamRepository = teamRepository;

    #region Stub data

    private static readonly IEnumerable<(InviteStatusEnum, long)> TEAM_IDS =
    [
        (InviteStatusEnum.Actual, 1),
        (InviteStatusEnum.Actual, 2),
        (InviteStatusEnum.Actual, 3),
        (InviteStatusEnum.Actual, 4),
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
        (InviteStatusEnum.Refused, 16)
    ];
    private static readonly List<long> PLAYER_IDS = [20, 21, 22, 23, 24, 25];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<TeamPlayerInvite>> GetSeedTeamPlayerInvitesAsync()
    {
        return await _teamPlayerInviteRepository.GetByIdsAsync(TEAM_IDS.Select(item => item.Item2), PLAYER_IDS).ConfigureAwait(true);
    }

    public async Task SeedTeamPlayerInvitesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<TeamPlayerInvite> invites = await CreateSeedTeamPlayerInvitesAsync().ConfigureAwait(true);

        TeamPlayerInvite[] seedInvites = await _teamPlayerInviteRepository.AddRangeIfNotExistsAsync([.. invites]).ConfigureAwait(true);

        await PublishTeamPlayerInvitesSeededEventAsync(seedInvites, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Invite, MetadataDomainEnum.TeamPlayerInvite, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<TeamPlayerInvite>> CreateSeedTeamPlayerInvitesAsync()
    {
        List<TeamPlayerInvite> result = [];

        foreach ((InviteStatusEnum, long) item in TEAM_IDS)
        {
            IEnumerable<TeamPlayerInvite> part = await BuildTeamPlayerInviteAsync(item.Item2, item.Item1).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<TeamPlayerInvite>> BuildTeamPlayerInviteAsync(long teamId, InviteStatusEnum status)
    {
        TeamEntity? team = await _teamRepository.GetByIdAsync(teamId).ConfigureAwait(true);

        Guid userId = team!.UserId;

        DateTime createdDate = _dateTimeService.Now;

        return PLAYER_IDS.Select(playerId => new TeamPlayerInvite()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
            UserId = userId,
            TeamId = teamId,
            PlayerId = playerId,
            StatusId = status,
            TeamComment = "Seed invite",
            PlayerComment = status == InviteStatusEnum.Refused ? "Seed player comment" : null
        });
    }

    private Task PublishTeamPlayerInvitesSeededEventAsync(IEnumerable<TeamPlayerInvite> teams, CancellationToken cancellationToken = default)
    {
        TeamPlayerInvitesSeeded @event = _mapper.Map<TeamPlayerInvitesSeeded>(teams);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}