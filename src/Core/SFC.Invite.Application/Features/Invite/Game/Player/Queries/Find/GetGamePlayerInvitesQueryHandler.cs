using AutoMapper;

using MediatR;

using SFC.Invite.Application.Features.Common.Dto.Pagination;
using SFC.Invite.Application.Features.Common.Models.Find;
using SFC.Invite.Application.Features.Common.Models.Find.Filters;
using SFC.Invite.Application.Features.Common.Models.Find.Paging;
using SFC.Invite.Application.Features.Common.Models.Find.Sorting;
using SFC.Invite.Application.Features.Invite.Game.Player.Common.Dto;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Extensions;
using SFC.Invite.Application.Interfaces.Common;
using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Game.Player;
using SFC.Invite.Domain.Entities.Invite.Game.Player;

namespace SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;
public class GetGamePlayerInvitesQueryHandler(
    IMapper mapper,
    IDateTimeService dateTimeService,
    IGamePlayerInviteRepository gamePlayerInviteRepository)
    : IRequestHandler<GetGamePlayerInvitesQuery, GetGamePlayerInvitesViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IGamePlayerInviteRepository _gamePlayerInviteRepository = gamePlayerInviteRepository;

    public async Task<GetGamePlayerInvitesViewModel> Handle(GetGamePlayerInvitesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<GamePlayerInvite>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<GamePlayerInvite, dynamic>> sorting = request.Sorting.BuildGamePlayerInviteSorting();

        FindParameters<GamePlayerInvite> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<GamePlayerInvite>(filters),
            Sorting = new Sortings<GamePlayerInvite>(sorting)
        };

        PagedList<GamePlayerInvite> pageList = await _gamePlayerInviteRepository.FindAsync(parameters)
                                                                                .ConfigureAwait(true);

        return new GetGamePlayerInvitesViewModel
        {
            Items = _mapper.Map<IEnumerable<GamePlayerInviteDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}