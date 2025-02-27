using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Data;

namespace SFC.Invite.Application.Features.Data.Common.Dto;
public class StatTypeDto : DataDto, IMapTo<StatType>
{
    public int CategoryId { get; set; }

    public int SkillId { get; set; }
}
