using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Common.Dto.Pagination;
using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Filters;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Team.Player.Common.Dto;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Extensions;
using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Team.Player;
using SFC.Invite.Domain.Entities.Invite.Team.Player;

namespace SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
public class GetTeamPlayerInvitesQueryHandler(
    IMapper mapper,
    IDateTimeService dateTimeService,
    ITeamPlayerInviteRepository teamPlayerInviteRepository)
    : IRequestHandler<GetTeamPlayerInvitesQuery, GetTeamPlayerInvitesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly ITeamPlayerInviteRepository _teamPlayerInviteRepository = teamPlayerInviteRepository;

    public async Task<GetTeamPlayerInvitesViewModel> Handle(GetTeamPlayerInvitesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<TeamPlayerInvite>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<TeamPlayerInvite, dynamic>> sorting = request.Sorting.BuildTeamPlayerInviteSorting();

        FindParameters<TeamPlayerInvite> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<TeamPlayerInvite>(filters),
            Sorting = new Sortings<TeamPlayerInvite>(sorting)
        };

        PagedList<TeamPlayerInvite> pageList = await _teamPlayerInviteRepository.FindAsync(parameters)
                                                                                .ConfigureAwait(true);

        return new GetTeamPlayerInvitesViewModel
        {
            Items = _mapper.Map<IEnumerable<TeamPlayerInviteDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}