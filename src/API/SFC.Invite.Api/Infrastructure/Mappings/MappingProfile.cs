using Google.Protobuf.WellKnownTypes;

using SFC.Invite.Api.Infrastructure.Models.Common;
using SFC.Invite.Application.Common.Mappings.Base;
using SFC.Invite.Application.Features.Common.Dto.Common;
using SFC.Invite.Application.Features.Common.Dto.Pagination;
using SFC.Invite.Application.Features.Invite.Common.Dto;
using SFC.Invite.Application.Features.Invite.Queries.Get;
using SFC.Invite.Application.Common.Extensions;

using System.Reflection;
using SFC.Invite.Application.Features.Invite.Queries.Find;
using SFC.Invite.Application.Features.Invite.Queries.Find.Dto.Filters;

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

        // contracts
        CreateMapInviteContracts();

        #endregion Complex types        
    }

    private void CreateMapInviteContracts()
    {
        // get invite
        CreateMap<InviteDto, SFC.Invite.Contracts.Models.Invite.Invite>();
        CreateMap<GetInviteViewModel, SFC.Invite.Contracts.Messages.Get.GetInviteResponse>();
        CreateMap<SFC.Invite.Contracts.Messages.Get.GetInviteRequest, GetInviteQuery>()
             .ForMember(p => p.InviteId, d => d.MapFrom(z => z.Id));
        CreateMap<InviteDto, SFC.Invite.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get invitemultiple
        // (filters)
        CreateMap<SFC.Invite.Contracts.Messages.Find.GetInvitesRequest, GetInvitesQuery>();
        CreateMap<SFC.Invite.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Invite.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Invite.Contracts.Messages.Find.Filters.GetInvitesFilter, GetInvitesFilterDto>();
        CreateMap(typeof(SFC.Invite.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetInvitesViewModel, SFC.Invite.Contracts.Messages.Find.GetInvitesResponse>();
        CreateMap<SFC.Invite.Application.Features.Invite.Common.Dto.InviteDto, SFC.Invite.Contracts.Models.Invite.Invite>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Invite.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}
