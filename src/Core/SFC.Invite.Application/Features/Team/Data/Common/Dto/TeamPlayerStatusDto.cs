using SFC.Invite.Application.Common.Dto.Data;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Team.Data;

namespace SFC.Invite.Application.Features.Team.Data.Common.Dto;
public class TeamPlayerStatusDto : DataDto, IMapTo<TeamPlayerStatus> { }