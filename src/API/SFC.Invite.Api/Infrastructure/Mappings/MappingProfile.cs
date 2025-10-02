using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Invite.Api.Infrastructure.Models.Common;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Common;
using SFC.Invite.Application.Common.Extensions;
using SFC.Invite.Application.Common.Mappings.Base;
using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Application.Features.Common.Dto.Pagination;
using SFC.Invite.Application.Features.Invite.Data.Queries.Common.Dto;
using SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;
using SFC.Invite.Application.Features.Invite.Team.Player.Common.Dto;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;

namespace SFC.Invite.Api.Infrastructure.Mappings;

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

        CreateMap<DateTime, Timestamp>()
            .ConvertUsing(value => DateTime.SpecifyKind(value, DateTimeKind.Utc).ToTimestamp());

        CreateMap<TimeSpan, Duration>()
            .ConvertUsing(value => Duration.FromTimeSpan(value));

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(RangeLimitModel<>), typeof(RangeLimitDto<>));

        #endregion Generic types

        #region Complex types

        // data
        CreateMapInviteDataContracts();

        // contracts
        CreateMapInviteContracts();

        #endregion Complex types        
    }

    private void CreateMapInviteDataContracts()
    {
        CreateMap<DataValueDto, SFC.Invite.Contracts.Models.Invite.Data.DataValue>();
        CreateMap<GetAllInviteDataViewModel, SFC.Invite.Contracts.Messages.Invite.Data.GetAll.GetAllInviteDataResponse>();
    }

    private void CreateMapInviteContracts()
    {
        // get invite
        CreateMap<TeamPlayerInviteDto, SFC.Invite.Contracts.Models.Invite.Team.Player.TeamPlayerInvite>();
        CreateMap<GetTeamPlayerInviteViewModel, SFC.Invite.Contracts.Messages.Invite.Team.Player.Get.GetTeamPlayerInviteResponse>();
        CreateMap<SFC.Invite.Contracts.Messages.Invite.Team.Player.Get.GetTeamPlayerInviteRequest, GetTeamPlayerInviteQuery>();
        CreateMap<TeamPlayerInviteDto, SFC.Invite.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get invites
        // (filters)
        CreateMap<SFC.Invite.Contracts.Messages.Invite.Team.Player.Find.GetTeamPlayerInvitesRequest, GetTeamPlayerInvitesQuery>();
        CreateMap<SFC.Invite.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Invite.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Invite.Contracts.Messages.Invite.Team.Player.Find.Filters.GetTeamPlayerInvitesFilter, GetTeamPlayerInvitesFilterDto>();
        CreateMap(typeof(SFC.Invite.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetTeamPlayerInvitesViewModel, SFC.Invite.Contracts.Messages.Invite.Team.Player.Find.GetTeamPlayerInvitesResponse>();
        CreateMap<TeamPlayerInviteDto, SFC.Invite.Contracts.Models.Invite.Team.Player.TeamPlayerInvite>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Invite.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}