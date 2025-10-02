using AutoMapper;

using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Domain.Entities.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Exist;
public class TeamPlayerInviteExistViewModel : IMapFrom<bool>
{
    public bool Exist { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<bool, TeamPlayerInviteExistViewModel>()
               .ConvertUsing(exist => new TeamPlayerInviteExistViewModel { Exist = exist });
    }
}