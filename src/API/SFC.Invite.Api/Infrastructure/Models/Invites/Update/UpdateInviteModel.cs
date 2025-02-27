using SFC.Invite.Api.Infrastructure.Models.Invites.Common;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Commands.Update;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Update;

/// <summary>
/// **Update** invite model.
/// </summary>
public class UpdateInviteModel : BaseInviteModel, IMapTo<UpdateInviteDto> { }
