using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Common.Dto;

namespace SFC.Invite.Application.Features.Invite.Commands.Update;
public class UpdateInviteDto : BaseInviteDto, IMapTo<InviteEntity>
{
    public new void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateInviteDto, InviteEntity>()
               .IncludeBase<BaseInviteDto, InviteEntity>();
    }
}
