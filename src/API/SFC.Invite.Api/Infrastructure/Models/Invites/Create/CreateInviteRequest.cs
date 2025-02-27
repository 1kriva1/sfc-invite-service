using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Commands.Create;
using SFC.Invite.Application.Common.Extensions;

namespace SFC.Invite.Api.Infrastructure.Models.Invites.Create;

/// <summary>
/// **Create** Invite request.
/// </summary>
public class CreateInviteRequest : IMapTo<CreateInviteCommand>
{
    /// <summary>
    /// Invite model.
    /// </summary>
    public CreateInviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateInviteRequest, CreateInviteCommand>()
                                                   .IgnoreAllNonExisting();
}
