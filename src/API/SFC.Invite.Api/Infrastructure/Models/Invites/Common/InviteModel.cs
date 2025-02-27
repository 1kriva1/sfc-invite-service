using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Common.Dto;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Common;

/// <summary>
/// Invite model.
/// </summary>
public class InviteModel : BaseInviteModel, IMapFrom<InviteDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }
}
