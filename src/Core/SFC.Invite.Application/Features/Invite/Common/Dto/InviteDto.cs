using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Application.Features.Invite.Common.Dto;
public class InviteDto: BaseInviteDto, IMapFrom<InviteEntity>
{
    public long Id { get; set; }

    public new void Mapping(Profile profile) => profile.CreateMap<InviteEntity, InviteDto>();
}
