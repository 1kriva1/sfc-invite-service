using AutoMapper;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Commands.Update;
using SFC.Invite.Application.Common.Extensions;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Update;

/// <summary>
/// **Update** invite request.
/// </summary>
public class UpdateInviteRequest : IMapTo<UpdateInviteCommand>
{
    /// <summary>
    /// Invite model.
    /// </summary>
    public UpdateInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateInviteRequest, UpdateInviteCommand>()
                                                   .IgnoreAllNonExisting();
}
