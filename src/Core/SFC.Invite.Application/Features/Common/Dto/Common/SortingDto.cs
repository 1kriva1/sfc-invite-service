using SFC.Invite.Application.Common.Enums;

namespace SFC.Invite.Application.Features.Common.Dto.Common;

/// <summary>
/// Sorting DTO.
/// </summary>
public class SortingDto
{
    public required string Name { get; set; }

    public SortingDirection Direction { get; set; }
}