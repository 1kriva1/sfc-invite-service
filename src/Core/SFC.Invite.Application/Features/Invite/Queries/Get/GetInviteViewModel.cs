using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Common.Dto;

namespace SFC.Invite.Application.Features.Invite.Queries.Get;
public class GetInviteViewModel : IMapFrom<InviteEntity>
{
    public required InviteDto Invite { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<InviteEntity, GetInviteViewModel>()
                                                   .ForMember(p => p.Invite, d => d.MapFrom(z => z));
}
