using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Data.Models;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;

namespace SFC.Invite.Infrastructure.Services.Invite.Data;
public class InviteDataService(IInviteStatusRepository inviteStatusesRepository) : IInviteDataService
{
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
}