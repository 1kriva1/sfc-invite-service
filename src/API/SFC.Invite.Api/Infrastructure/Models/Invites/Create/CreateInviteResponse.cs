using AutoMapper;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Commands.Create;
using SFC.Invite.Api.Infrastructure.Models.Invites.Common;
using SFC.Invite.Api.Infrastructure.Models.Base;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Create;

/// <summary>
/// **Create** invite response model.
/// </summary>
public class CreateInviteResponse :
    BaseErrorResponse, IMapFrom<CreateInviteViewModel>
{
    /// <summary>
    /// Invite model.
    /// </summary>
    public InviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateInviteViewModel, CreateInviteResponse>()
                                                   .IgnoreAllNonExisting();
}
