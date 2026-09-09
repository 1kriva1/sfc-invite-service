using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Exist;
public class GamePlayerInviteExistViewModel : IMapFrom<bool>
{
    public bool Exist { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<bool, GamePlayerInviteExistViewModel>()
               .ConvertUsing(exist => new GamePlayerInviteExistViewModel { Exist = exist });
    }
}