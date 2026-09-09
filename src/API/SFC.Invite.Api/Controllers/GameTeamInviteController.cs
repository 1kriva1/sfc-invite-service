using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Create;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Creates;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Exist;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Find;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Get;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Gets;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Update.General;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Team.Update.Refuse;
using SFC.Invite.Api.Infrastructure.Models.Pagination;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Create;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Creates;
using SFC.Invite.Application.Features.Invite.Game.Team.Commands.Update;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Exist;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Find.Dto.Filters;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Get;
using SFC.Invite.Application.Features.Invite.Game.Team.Queries.Gets;
using SFC.Invite.Infrastructure.Constants;

namespace SFC.Invite.Api.Controllers;

/// <summary>
/// Game Team invite controller:
/// - create invite
/// - cancel/accept/refuse invite
/// - get/find invites
/// </summary>
[Tags("Game Team Invites")]
[Route("api/Invites")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class GameTeamInviteController : ApiControllerBase
{
    /// <summary>
    /// Check if Game Team invite exist.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="status">Game Team status Id.</param>
    /// <returns>An ActionResult of type GameTeamInviteExistResponse</returns>
    /// <response code="200">Returns Game Team invite existence check result.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet("Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<GameTeamInviteExistResponse>> GameTeamInviteExistAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromQuery] int? status)
    {
        GameTeamInviteExistQuery query = new() { GameId = gameId, TeamId = teamId, Status = (InviteStatusEnum?)status };

        GameTeamInviteExistViewModel model = await Mediator.Send(query)
                                                           .ConfigureAwait(false);

        return Ok(Mapper.Map<GameTeamInviteExistResponse>(model));
    }

    /// <summary>
    /// Create new Game invite for Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Create Game invite for Team request.</param>
    /// <returns>An ActionResult of type CreateGameTeamInviteResponse</returns>
    /// <response code="201">Returns **new** created Game Team invite.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateGameTeamInviteResponse>> CreateGameTeamInviteAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromBody] CreateGameTeamInviteRequest request)
    {
        CreateGameTeamInviteCommand command = Mapper.Map<CreateGameTeamInviteCommand>(request)
                                                      .SetGameId(gameId)
                                                      .SetTeamId(teamId);

        CreateGameTeamInviteViewModel model = await Mediator.Send(command)
                                                              .ConfigureAwait(false);

        return CreatedAtRoute("GetGameTeamInvite",
            new { gameId, teamId, inviteId = model.Invite.Id },
            Mapper.Map<CreateGameTeamInviteResponse>(model));
    }

    /// <summary>
    /// Create new Game invites for Teams.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="request">Create Game invites for Teams request.</param>
    /// <returns>An ActionResult of type CreateGameTeamInvitesResponse</returns>
    /// <response code="200">Returns **new** created Game Team invites.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Teams")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreatesGameTeamInviteResponse>> CreatesGameTeamInviteAsync(
        [FromRoute] long gameId, [FromBody] CreatesGameTeamInviteRequest request)
    {
        CreatesGameTeamInviteCommand command = Mapper.Map<CreatesGameTeamInviteCommand>(request)
                                                       .SetGameId(gameId);

        CreatesGameTeamInviteViewModel model = await Mediator.Send(command)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<CreatesGameTeamInviteResponse>(model));
    }

    /// <summary>
    /// Update Game invite for Team by Game.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="inviteId">Game Team invite Id.</param>
    /// <param name="request">Update Game invite for Team request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** updated.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateGameTeamInviteAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long inviteId, [FromBody] UpdateGameTeamInviteRequest request)
    {
        UpdateGameTeamInviteCommand command = Mapper.Map<UpdateGameTeamInviteCommand>(request)
                                                      .SetId(inviteId)
                                                      .SetGameId(gameId)
                                                      .SetTeamId(teamId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Cancel Game invite for Team by Game.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="inviteId">Game Team invite Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** canceled.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Teams/{teamId}/Cancel")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelGameTeamInviteAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long inviteId)
    {
        UpdateGameTeamInviteCommand command = InviteStatusEnum.Canceled
            .BuildUpdateGameTeamInviteCommand(inviteId, gameId, teamId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Refuse Game invite for Team by Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="inviteId">Game Team invite Id.</param>
    /// <param name="request">Refuse Game invite for Team request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** refused.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Teams/{teamId}/Refuse")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> RefuseGameTeamInviteAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long inviteId, [FromBody] RefuseGameTeamInviteRequest request)
    {
        UpdateGameTeamInviteCommand command = Mapper.Map<UpdateGameTeamInviteCommand>(request)
                                                      .SetId(inviteId)
                                                      .SetGameId(gameId)
                                                      .SetTeamId(teamId)
                                                      .SetStatus(InviteStatusEnum.Refused);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Accept Game invite for Team by Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="inviteId">Game Team invite Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** accepted.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Teams/{teamId}/Accept")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AcceptGameTeamInviteAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long inviteId)
    {
        UpdateGameTeamInviteCommand command = InviteStatusEnum.Accepted
            .BuildUpdateGameTeamInviteCommand(inviteId, gameId, teamId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return Game invite for Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="inviteId">Game Team invite Id.</param>
    /// <returns>An ActionResult of type GetGameTeamInviteResponse</returns>
    /// <response code="200">Returns Game invite for Team model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    [HttpGet("{inviteId}/Games/{gameId}/Teams/{teamId}", Name = "GetGameTeamInvite")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetGameTeamInviteResponse>> GetGameTeamInviteAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long inviteId)
    {
        GetGameTeamInviteQuery query = new() { Id = inviteId, GameId = gameId, TeamId = teamId };

        GetGameTeamInviteViewModel invite = await Mediator.Send(query)
                                                            .ConfigureAwait(false);

        return Ok(Mapper.Map<GetGameTeamInviteResponse>(invite));
    }

    /// <summary>
    /// Return Game Team invite models by Game Id.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <returns>An ActionResult of type GetAllGameTeamInvitesResponse</returns>
    /// <response code="200">Returns Game Team invite models.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Teams")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetsGameTeamInviteResponse>> GetsGameTeamInviteAsync([FromRoute] long gameId)
    {
        GetsGameTeamInviteQuery query = new() { GameId = gameId };

        GetsGameTeamInviteViewModel gameTeamInvites = await Mediator.Send(query)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<GetsGameTeamInviteResponse>(gameTeamInvites));
    }

    /// <summary>
    /// Return list of Game Team invites.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <param name="request">Get Game Team invites request.</param>
    /// <returns>An ActionResult of type GetGameTeamInvitesResponse</returns>
    /// <response code="200">Returns list of Game Team invites with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Teams/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetGameTeamInvitesResponse>> GetGameTeamInvitesAsync([FromRoute] long gameId, [FromQuery] GetGameTeamInvitesRequest request)
    {
        BasePaginationRequest<GetGameTeamInvitesViewModel, GetGameTeamInvitesFilterDto> query =
            Mapper.Map<GetGameTeamInvitesQuery>(request)
                  .SetGameId(gameId);

        GetGameTeamInvitesViewModel result = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetGameTeamInvitesResponse>(result));
    }
}