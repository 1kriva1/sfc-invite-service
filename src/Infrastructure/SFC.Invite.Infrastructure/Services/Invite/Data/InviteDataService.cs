using AutoMapper;

using MassTransit;

using MediatR;

using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Data.Models;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Invite.Infrastructure.Extensions;
using SFC.Invite.Messages.Events.Invite.Data;

namespace SFC.Invite.Infrastructure.Services.Invite.Data;
public class InviteDataService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IInviteStatusRepository inviteStatusesRepository) : IInviteDataService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IInviteStatusRepository _inviteStatusesRepository = inviteStatusesRepository;

    public async Task<GetAllInviteDataModel> GetAllInviteDataAsync()
    {
        return new()
        {
            InviteStatuses = await _inviteStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetTeamDataModel> GetTeamDataAsync()
    {
        return new()
        {
            InviteStatuses = await _inviteStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task<GetGameDataModel> GetGameDataAsync()
    {
        return new()
        {
            InviteStatuses = await _inviteStatusesRepository.ListAllAsync().ConfigureAwait(false)
        };
    }

    public async Task PublishDataInitializedEventAsync(CancellationToken cancellationToken)
    {
        GetAllInviteDataModel model = await GetAllInviteDataAsync().ConfigureAwait(true);

        DataInitialized @event = _mapper.BuildInviteDataInitializedEvent(model);

        await _publisher.Publish(@event, cancellationToken)
                        .ConfigureAwait(false);
    }
}