using SFC.Invite.Application.Features.Common.Dto.Common;

namespace SFC.Invite.Application.Common.Dto.Player.Filters;
public class PlayerStatsBySkillRangeLimitFilterDto : RangeLimitDto<short?>
{
    public int Skill { get; set; }
}
