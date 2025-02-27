using AutoMapper;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Queries.Get;
using SFC.Invite.Api.Infrastructure.Models.Invites.Common;
using SFC.Invite.Api.Infrastructure.Models.Base;

#pragma warning disable CA1716
namespace SFC.Invite.Api.Infrastructure.Models.Invites.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** invite response.
/// </summary>
public class GetInviteResponse :
    BaseErrorResponse, IMapFrom<GetInviteViewModel>
{
    /// <summary>
    /// Invite model.
    /// </summary>
    public InviteModel Invite { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetInviteViewModel, GetInviteResponse>()
                                                   .IgnoreAllNonExisting();
}
