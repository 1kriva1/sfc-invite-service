using SFC.Invite.Application.Common.Enums;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Game.Data.Common.Dto;

namespace SFC.Invite.Application.Features.Game.Data.Commands.Reset;
public class ResetGameDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetGameData; }

    public IEnumerable<GameStatusDto> GameStatuses { get; init; } = [];

    public IEnumerable<GamePlayerStatusDto> GamePlayerStatuses { get; init; } = [];

    public IEnumerable<GameTeamStatusDto> GameTeamStatuses { get; init; } = [];

    public IEnumerable<GameTeamIndexDto> GameTeamIndexes { get; init; } = [];
}