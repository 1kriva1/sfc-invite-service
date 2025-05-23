using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Team.General;

namespace SFC.Invite.Application.Common.Dto.Team.General;
public class TeamFinancialProfileDto : IMapFromReverse<TeamFinancialProfile>
{
    public bool FreePlay { get; set; }
}