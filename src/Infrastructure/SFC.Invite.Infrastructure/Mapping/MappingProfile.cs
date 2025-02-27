using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Invite.Application.Common.Mappings.Base;
using SFC.Invite.Application.Features.Data.Commands.Reset;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Features.Identity.Commands.Create;
using SFC.Invite.Application.Features.Identity.Commands.CreateRange;
using SFC.Invite.Application.Common.Dto.Identity;
using SFC.Invite.Application.Features.Data.Common.Dto;
using SFC.Invite.Application.Features.Player.Commands.Create;
using SFC.Invite.Application.Features.Player.Commands.Update;
using SFC.Invite.Application.Features.Player.Commands.CreateRange;
using SFC.Invite.Application.Common.Dto.Player.General;

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
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<SFC.Data.Messages.Events.DataInitialized, ResetDataCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, FootballPositionDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, GameStyleDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, StatCategoryDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, StatSkillDto>();
        CreateMap<SFC.Data.Messages.Models.Stats.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, WorkingFootDto>();
    }

    #endregion Data

    #region Identity

    private void CreateMapIdentityMessages()
    {
        CreateMap<SFC.Identity.Messages.Events.UserCreated, CreateUserCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Identity.Messages.Models.User>, CreateUsersCommand>()
            .ForMember(p => p.Users, d => d.MapFrom(z => z));

        CreateMap<SFC.Identity.Messages.Models.User, UserDto>();
    }

    private void CreateMapIdentityContracts()
    {
        CreateMap<Guid, SFC.Identity.Contracts.Messages.Get.GetUserRequest>()
            .ConvertUsing(id => new SFC.Identity.Contracts.Messages.Get.GetUserRequest { Id = id.ToString() });
        CreateMap<SFC.Identity.Contracts.Models.Get.User, UserDto>();
    }

    #endregion Identity

    #region Player

    private void CreateMapPlayerMessages()
    {
        CreateMap<SFC.Player.Messages.Events.PlayerCreated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.PlayerUpdated, UpdatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.PlayerUpdated, CreatePlayerCommand>().IgnoreAllNonExisting();

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
        CreateMap<long, SFC.Player.Contracts.Messages.Get.GetPlayerRequest>()
            .ConvertUsing(id => new SFC.Player.Contracts.Messages.Get.GetPlayerRequest { Id = id });

        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayer, PlayerDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerProfile, PlayerProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Common.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerFootballProfile, PlayerFootballProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerStats, PlayerStatsDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerStatPoints, PlayerStatPointsDto>();
        CreateMap<SFC.Player.Contracts.Models.Common.Player.PlayerStatValue, PlayerStatValueDto>();
    }

    #endregion Player
}
