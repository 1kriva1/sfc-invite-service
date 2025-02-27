using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Common.Dto.Pagination;
using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Filters;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Common.Dto;
using SFC.Invite.Application.Features.Invite.Queries.Find.Extensions;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite;

namespace SFC.Invite.Application.Features.Invite.Queries.Find;
public class GetInvitesQueryHandler(
    IMapper mapper,
    IInviteRepository inviteRepository)
    : IRequestHandler<GetInvitesQuery, GetInvitesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IInviteRepository _inviteRepository = inviteRepository;

    public async Task<GetInvitesViewModel> Handle(GetInvitesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<InviteEntity>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<InviteEntity, dynamic>>? sorting = request.Sorting.BuildInviteSearchSorting();

        FindParameters<InviteEntity> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<InviteEntity>(filters),
            Sorting = sorting != null
                ? new Sortings<InviteEntity>(sorting)
                : new Sortings<InviteEntity>()
        };

        PagedList<InviteEntity> pageList = await _inviteRepository
                                                             .FindAsync(parameters)
                                                             .ConfigureAwait(true);

        return new GetInvitesViewModel
        {
            Items = _mapper.Map<IEnumerable<InviteDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}
