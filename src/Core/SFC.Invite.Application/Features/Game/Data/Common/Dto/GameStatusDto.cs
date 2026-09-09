using SFC.Invite.Application.Common.Dto.Data;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Game.Data;

namespace SFC.Invite.Application.Features.Game.Data.Common.Dto;
public class GameStatusDto : DataDto, IMapTo<GameStatus> { }