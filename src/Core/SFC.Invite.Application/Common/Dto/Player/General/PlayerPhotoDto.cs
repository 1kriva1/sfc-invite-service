using AutoMapper;

using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Converters.File;
using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Domain.Entities.Player;

namespace SFC.Invite.Application.Common.Dto.Player.General;
public class PlayerPhotoDto : FileDto, IMapFromReverse<PlayerPhoto>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerPhoto, PlayerPhotoDto>();

        profile.CreateMap<string?, PlayerPhotoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<PlayerPhotoDto>>();

        profile.CreateMap<PlayerPhotoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<PlayerPhotoDto>>();

        profile.CreateMap<PlayerPhotoDto, PlayerPhoto>()
               .IgnoreAllNonExisting();
    }
}
