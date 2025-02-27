namespace SFC.Invite.Application.Features.Data.Common.Dto;

/// <summary>
/// Parent class for all data entities.
/// </summary>
public class DataDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
