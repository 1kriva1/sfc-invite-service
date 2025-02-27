using SFC.Invite.Api.Infrastructure.Models.Invites.Common;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Commands.Create;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Create;

/// <summary>
/// **Create** invite model.
/// </summary>
public class CreateInviteModel : BaseInviteModel, IMapTo<CreateInviteDto> { }
