using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Invite.Application.Common.Dto.Identity;
using SFC.Invite.Application.Common.Dto.Player.General;
using SFC.Invite.Application.Common.Dto.Team.General;
using SFC.Invite.Application.Common.Dto.Team.Player;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Base;
using SFC.Invite.Application.Features.Data.Commands.Reset;
using SFC.Invite.Application.Features.Data.Common.Dto;
using SFC.Invite.Application.Features.Identity.Commands.Create;
using SFC.Invite.Application.Features.Identity.Commands.CreateRange;
using SFC.Invite.Application.Features.Player.Commands.Create;
using SFC.Invite.Application.Features.Player.Commands.CreateRange;
using SFC.Invite.Application.Features.Player.Commands.Update;
using SFC.Invite.Application.Features.Team.Data.Commands.Reset;
using SFC.Invite.Application.Features.Team.Data.Common.Dto;
using SFC.Invite.Application.Features.Team.General.Commands.Create;
using SFC.Invite.Application.Features.Team.General.Commands.CreateRange;
using SFC.Invite.Application.Features.Team.General.Commands.Update;
using SFC.Invite.Application.Features.Team.Player.Commands.Create;
using SFC.Invite.Application.Features.Team.Player.Commands.CreateRange;
using SFC.Invite.Application.Features.Team.Player.Commands.Update;
using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Messages.Commands.Team.Data;
using SFC.Invite.Messages.Events.Invite.Team.Player;
using SFC.Invite.Messages.Models.Data;

namespace SFC.Invite.Infrastructure.Mapping;
public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types       

        CreateMap<Timestamp, DateTime>()
           .ConvertUsing(value => value.ToDateTime());

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Data

        // messages        
        CreateMapDataMessages();

        #endregion Data

        #region Identity

        // messages        
        CreateMapIdentityMessages();

        // contracts        
        CreateMapIdentityContracts();

        #endregion Identity

        #region Player

        // messages
        CreateMapPlayerMessages();

        // contracts
        CreateMapPlayerContracts();

        #endregion Player

        #region Invite

        CreateMapInviteMessages();

        #endregion Invite

        #region Team

        CreateMapTeamMessages();

        #endregion Team
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<SFC.Data.Messages.Events.Data.DataInitialized, ResetDataCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, FootballPositionDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, GameStyleDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, StatCategoryDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, StatSkillDto>();
        CreateMap<SFC.Data.Messages.Models.Data.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, WorkingFootDto>();
        CreateMap<SFC.Data.Messages.Models.Data.DataValue, ShirtDto>();
    }

    #endregion Data

    #region Identity

    private void CreateMapIdentityMessages()
    {
        CreateMap<SFC.Identity.Messages.Events.User.UserCreated, CreateUserCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Identity.Messages.Models.User.User>, CreateUsersCommand>()
            .ForMember(p => p.Users, d => d.MapFrom(z => z));

        CreateMap<SFC.Identity.Messages.Models.User.User, UserDto>();
    }

    private void CreateMapIdentityContracts()
    {
        CreateMap<Guid, SFC.Identity.Contracts.Messages.User.Get.GetUserRequest>()
            .ConvertUsing(id => new SFC.Identity.Contracts.Messages.User.Get.GetUserRequest { Id = id.ToString() });
        CreateMap<SFC.Identity.Contracts.Models.User.User, UserDto>();
    }

    #endregion Identity

    #region Player

    private void CreateMapPlayerMessages()
    {
        CreateMap<SFC.Player.Messages.Events.Player.General.PlayerCreated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.Player.General.PlayerUpdated, UpdatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.Player.General.PlayerUpdated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Player.Messages.Models.Player.Player>, CreatePlayersCommand>()
            .ForMember(p => p.Players, d => d.MapFrom(z => z));

        CreateMap<SFC.Player.Messages.Commands.Player.SeedPlayers, CreatePlayersCommand>();

        CreateMap<SFC.Player.Messages.Models.Player.Player, PlayerDto>()
            .ForPath(p => p.Stats.Values, d => d.MapFrom(z => z.Stats))
            .ForPath(p => p.Stats.Points, d => d.MapFrom(z => z.Points))
            .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
            .ForPath(p => p.Profile.Football, d => d.MapFrom(z => z.FootballProfile))
            .ForPath(p => p.Profile.General.Photo, d => d.MapFrom(z => z.Photo))
            .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
            .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));

        // stats
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStat, PlayerStatValueDto>()
            .ForPath(p => p.Type, d => d.MapFrom(z => z.TypeId));
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStatPoints, PlayerStatPointsDto>();

        // general profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerPhoto, PlayerPhotoDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailableDay, DayOfWeek>().ConvertUsing(day => day.Day);
        CreateMap<SFC.Player.Messages.Models.Player.PlayerTag, string>().ConvertUsing(tag => tag.Value);

        // football profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerFootballProfile, PlayerFootballProfileDto>()
            .ForPath(p => p.AdditionalPosition, d => d.MapFrom(z => z.AdditionalPositionId))
            .ForPath(p => p.Position, d => d.MapFrom(z => z.PositionId))
            .ForPath(p => p.GameStyle, d => d.MapFrom(z => z.GameStyleId))
            .ForPath(p => p.WorkingFoot, d => d.MapFrom(z => z.WorkingFootId));
    }

    private void CreateMapPlayerContracts()
    {
        CreateMap<long, SFC.Player.Contracts.Messages.Player.General.Get.GetPlayerRequest>()
            .ConvertUsing(id => new SFC.Player.Contracts.Messages.Player.General.Get.GetPlayerRequest { Id = id });

        CreateMap<SFC.Player.Contracts.Models.Player.General.Player, PlayerDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerProfile, PlayerProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerFootballProfile, PlayerFootballProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerStats, PlayerStatsDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerStatPoints, PlayerStatPointsDto>();
        CreateMap<SFC.Player.Contracts.Models.Player.General.PlayerStatValue, PlayerStatValueDto>();
    }

    #endregion Player

    #region Team

    private void CreateMapTeamMessages()
    {
        // data
        // events
        CreateMap<SFC.Team.Messages.Events.Team.Data.DataInitialized, ResetTeamDataCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<SFC.Team.Messages.Models.Data.DataValue, TeamPlayerStatusDto>();
        CreateMap<InviteStatus, SFC.Team.Messages.Models.Data.DataValue>();

        // domain
        // team
        // events
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamCreated, CreateTeamCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamUpdated, UpdateTeamCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamUpdated, CreateTeamCommand>().IgnoreAllNonExisting();
        // commands
        CreateMap<SFC.Team.Messages.Commands.Team.General.SeedTeams, CreateTeamsCommand>();
        // models
        CreateMap<IEnumerable<SFC.Team.Messages.Models.Team.General.Team>, CreateTeamsCommand>()
           .ForMember(p => p.Teams, d => d.MapFrom(z => z));
        CreateMap<SFC.Team.Messages.Models.Team.General.Team, TeamDto>()
           .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
           .ForPath(p => p.Profile.Financial, d => d.MapFrom(z => z.FinancialProfile))
           .ForPath(p => p.Profile.Inventary.Shirts, d => d.MapFrom(z => z.Shirts))
           .ForPath(p => p.Profile.General.Logo, d => d.MapFrom(z => z.Logo))
           .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
           .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamGeneralProfile, TeamGeneralProfileDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamFinancialProfile, TeamFinancialProfileDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamLogo, TeamLogoDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamAvailability, TeamAvailabilityDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamTag, string>().ConvertUsing(tag => tag.Value);
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamShirt, int>().ConvertUsing(shirt => shirt.ShirtId);
        // team player
        // events
        CreateMap<SFC.Team.Messages.Events.Team.Player.TeamPlayerCreated, CreateTeamPlayerCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.Player.TeamPlayerUpdated, UpdateTeamPlayerCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<IEnumerable<SFC.Team.Messages.Models.Team.Player.TeamPlayer>, CreateTeamPlayersCommand>()
           .ForMember(p => p.TeamPlayers, d => d.MapFrom(z => z));
        CreateMap<SFC.Team.Messages.Models.Team.Player.TeamPlayer, TeamPlayerDto>();
    }

    #endregion Team

    #region Invite

    private void CreateMapInviteMessages()
    {
        // data
        //commands
        CreateMap<SFC.Invite.Messages.Commands.Data.InitializeData, ResetDataCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, FootballPositionDto>();
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, GameStyleDto>();
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, StatCategoryDto>();
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, StatSkillDto>();
        CreateMap<SFC.Invite.Messages.Models.Data.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, WorkingFootDto>();
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, ShirtDto>();
        // invite data
        CreateMap<SFC.Invite.Domain.Entities.Invite.Data.InviteStatus, DataValue>();

        // team
        // commands
        CreateMap<InitializeData, ResetTeamDataCommand>().IgnoreAllNonExisting();
        //models
        CreateMap<SFC.Invite.Messages.Models.Data.DataValue, TeamPlayerStatusDto>();

        // team player invite
        // events
        CreateMap<TeamPlayerInviteEntity, TeamPlayerInviteCreated>()
            .ForMember(p => p.Invite, d => d.MapFrom(z => z));
        CreateMap<TeamPlayerInviteEntity, TeamPlayerInviteUpdated>()
            .ForMember(p => p.Invite, d => d.MapFrom(z => z));
        CreateMap<IEnumerable<TeamPlayerInviteEntity>, TeamPlayerInvitesSeeded>()
           .ForMember(p => p.TeamPlayerInvites, d => d.MapFrom(z => z));
        //commands
        CreateMap<IEnumerable<TeamPlayerInviteEntity>, SFC.Invite.Messages.Commands.Invite.Team.Player.SeedTeamPlayerInvites>()
            .ForMember(p => p.TeamPlayerInvites, d => d.MapFrom(z => z));
        // models
        CreateMap<TeamPlayerInviteEntity, Messages.Models.Invite.Team.Player.TeamPlayerInvite>();
    }

    #endregion Invite    
}