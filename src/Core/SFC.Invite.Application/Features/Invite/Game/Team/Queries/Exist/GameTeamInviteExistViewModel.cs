using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Exist;
public class GameTeamInviteExistViewModel : IMapFrom<bool>
{
    public bool Exist { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<bool, GameTeamInviteExistViewModel>()
               .ConvertUsing(exist => new GameTeamInviteExistViewModel { Exist = exist });
    }
}