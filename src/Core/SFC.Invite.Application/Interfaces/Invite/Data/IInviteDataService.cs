using SFC.Invite.Application.Interfaces.Invite.Data.Models;

namespace SFC.Invite.Application.Interfaces.Invite.Data;
public interface IInviteDataService
{
    Task<GetAllInviteDataModel> GetAllInviteDataAsync();

    Task<GetTeamDataModel> GetTeamDataAsync();
}