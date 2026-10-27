using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Data.Queries.Common.Dto;

namespace SFC.Invite.Api.Infrastructure.Models.Invite.Data.Common;

/// <summary>
/// Data value.
/// </summary>
public class DataValueModel : IMapFrom<DataValueDto>
{
    /// <summary>
    /// Unique identificator of data type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of data type.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Describe data type.
    /// </summary>
    public required string Title { get; set; }
}