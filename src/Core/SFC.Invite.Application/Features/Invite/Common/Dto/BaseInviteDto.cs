using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Application.Features.Invite.Common.Dto;
public class BaseInviteDto : IMapToReverse<InviteEntity>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<BaseInviteDto, InviteEntity>()
               .ReverseMap();
    }
}
