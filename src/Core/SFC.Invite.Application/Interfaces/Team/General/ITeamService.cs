using SFC.Invite.Application.Common.Dto.Team.General;

namespace SFC.Invite.Application.Interfaces.Team.General;
public interface ITeamService
{
    Task<TeamDto?> GetTeamAsync(long id, CancellationToken cancellationToken = default);
}