using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Team.General;

namespace SFC.Invite.Application.Common.Dto.Team.General;
public class TeamInventaryProfileDto : IMapToReverse<TeamInventaryProfile>
{
    public IEnumerable<int> Shirts { get; set; } = [];

    public bool HasManiches { get; set; }
}