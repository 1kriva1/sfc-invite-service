using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Common.Dto.Pagination;
using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Filters;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Game.Team.Common.Dto;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Extensions;
using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Team;
using SFC.Invite.Domain.Entities.Invite.Game.Team;

namespace SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find;
public class GetGameTeamInvitesQueryHandler(
    IMapper mapper,
    IDateTimeService dateTimeService,
    IGameTeamInviteRepository gameTeamInviteRepository)
    : IRequestHandler<GetGameTeamInvitesQuery, GetGameTeamInvitesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IGameTeamInviteRepository _gameTeamInviteRepository = gameTeamInviteRepository;

    public async Task<GetGameTeamInvitesViewModel> Handle(GetGameTeamInvitesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<GameTeamInvite>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<GameTeamInvite, dynamic>> sorting = request.Sorting.BuildGameTeamInviteSorting();

        FindParameters<GameTeamInvite> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<GameTeamInvite>(filters),
            Sorting = new Sortings<GameTeamInvite>(sorting)
        };

        PagedList<GameTeamInvite> pageList = await _gameTeamInviteRepository.FindAsync(parameters)
                                                                                .ConfigureAwait(true);

        return new GetGameTeamInvitesViewModel
        {
            Items = _mapper.Map<IEnumerable<GameTeamInviteDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}