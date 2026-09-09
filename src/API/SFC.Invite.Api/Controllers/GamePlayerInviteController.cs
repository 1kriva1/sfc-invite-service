using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Create;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Creates;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Exist;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Find;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Get;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Gets;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Update.General;
using SFC.Invite.Api.Infrastructure.Models.Invite.Game.Player.Update.Refuse;
using SFC.Invite.Api.Infrastructure.Models.Pagination;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Create;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Creates;
using SFC.Invite.Application.Features.Invite.Game.Player.Commands.Update;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Exist;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Find.Dto.Filters;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Get;
using SFC.Invite.Application.Features.Invite.Game.Player.Queries.Gets;
using SFC.Invite.Infrastructure.Constants;

namespace SFC.Invite.Api.Controllers;

/// <summary>
/// Game player invite controller:
/// - create invite
/// - cancel/accept/refuse invite
/// - get/find invites
/// </summary>
[Tags("Game Player Invites")]
[Route("api/Invites")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class GamePlayerInviteController : ApiControllerBase
{
    /// <summary>
    /// Check if Game player invite exist.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="status">Game player status Id.</param>
    /// <returns>An ActionResult of type GamePlayerInviteExistResponse</returns>
    /// <response code="200">Returns Game player invite existence check result.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet("Games/{gameId}/Players/{playerId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<GamePlayerInviteExistResponse>> GamePlayerInviteExistAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromQuery] int? status)
    {
        GamePlayerInviteExistQuery query = new() { GameId = gameId, PlayerId = playerId, Status = (InviteStatusEnum?)status };

        GamePlayerInviteExistViewModel model = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        return Ok(Mapper.Map<GamePlayerInviteExistResponse>(model));
    }

    /// <summary>
    /// Create new Game invite for player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="request">Create Game invite for player request.</param>
    /// <returns>An ActionResult of type CreateGamePlayerInviteResponse</returns>
    /// <response code="201">Returns **new** created Game player invite.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Players/{playerId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateGamePlayerInviteResponse>> CreateGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromBody] CreateGamePlayerInviteRequest request)
    {
        CreateGamePlayerInviteCommand command = Mapper.Map<CreateGamePlayerInviteCommand>(request)
                                                      .SetGameId(gameId)
                                                      .SetPlayerId(playerId);

        CreateGamePlayerInviteViewModel model = await Mediator.Send(command)
                                                              .ConfigureAwait(false);

        return CreatedAtRoute("GetGamePlayerInvite",
            new { gameId, playerId, inviteId = model.Invite.Id },
            Mapper.Map<CreateGamePlayerInviteResponse>(model));
    }

    /// <summary>
    /// Create new Game invites for players.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="request">Create Game invites for players request.</param>
    /// <returns>An ActionResult of type CreateGamePlayerInvitesResponse</returns>
    /// <response code="200">Returns **new** created Game player invites.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Players")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreatesGamePlayerInviteResponse>> CreatesGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromBody] CreatesGamePlayerInviteRequest request)
    {
        CreatesGamePlayerInviteCommand command = Mapper.Map<CreatesGamePlayerInviteCommand>(request)
                                                       .SetGameId(gameId);

        CreatesGamePlayerInviteViewModel model = await Mediator.Send(command)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<CreatesGamePlayerInviteResponse>(model));
    }

    [HttpPut("{inviteId}/Games/{gameId}/Players/{playerId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long inviteId, [FromBody] UpdateGamePlayerInviteRequest request)
    {
        UpdateGamePlayerInviteCommand command = Mapper.Map<UpdateGamePlayerInviteCommand>(request)
                                                      .SetId(inviteId)
                                                      .SetGameId(gameId)
                                                      .SetPlayerId(playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Cancel Game invite for player by Game.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Game player invite Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** canceled.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Players/{playerId}/Cancel")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long inviteId)
    {
        UpdateGamePlayerInviteCommand command = InviteStatusEnum.Canceled
            .BuildUpdateGamePlayerInviteCommand(inviteId, gameId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Refuse Game invite for player by player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Game player invite Id.</param>
    /// <param name="request">Refuse Game invite for player request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** refused.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Players/{playerId}/Refuse")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> RefuseGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long inviteId, [FromBody] RefuseGamePlayerInviteRequest request)
    {
        UpdateGamePlayerInviteCommand command = Mapper.Map<UpdateGamePlayerInviteCommand>(request)
                                                      .SetId(inviteId)
                                                      .SetGameId(gameId)
                                                      .SetPlayerId(playerId)
                                                      .SetStatus(InviteStatusEnum.Refused);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Accept Game invite for player by player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Game player invite Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** accepted.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Games/{gameId}/Players/{playerId}/Accept")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AcceptGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long inviteId)
    {
        UpdateGamePlayerInviteCommand command = InviteStatusEnum.Accepted
            .BuildUpdateGamePlayerInviteCommand(inviteId, gameId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return Game invite for player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Game player invite Id.</param>
    /// <returns>An ActionResult of type GetGamePlayerInviteResponse</returns>
    /// <response code="200">Returns Game invite for player model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    [HttpGet("{inviteId}/Games/{gameId}/Players/{playerId}", Name = "GetGamePlayerInvite")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetGamePlayerInviteResponse>> GetGamePlayerInviteAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long inviteId)
    {
        GetGamePlayerInviteQuery query = new() { Id = inviteId, GameId = gameId, PlayerId = playerId };

        GetGamePlayerInviteViewModel invite = await Mediator.Send(query)
                                                            .ConfigureAwait(false);

        return Ok(Mapper.Map<GetGamePlayerInviteResponse>(invite));
    }

    /// <summary>
    /// Return Game player invite models by Game Id.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <returns>An ActionResult of type GetAllGamePlayerInvitesResponse</returns>
    /// <response code="200">Returns Game player invite models.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Players")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetsGamePlayerInviteResponse>> GetGamePlayerInvitesAsync([FromRoute] long gameId)
    {
        GetsGamePlayerInviteQuery query = new() { GameId = gameId };

        GetsGamePlayerInviteViewModel GamePlayerInvites = await Mediator.Send(query)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<GetsGamePlayerInviteResponse>(GamePlayerInvites));
    }

    /// <summary>
    /// Return list of Game player invites.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <param name="request">Get Game player invites request.</param>
    /// <returns>An ActionResult of type GetGamePlayerInvitesResponse</returns>
    /// <response code="200">Returns list of Game player invites with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Players/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetGamePlayerInvitesResponse>> GetGamePlayerInvitesAsync([FromRoute] long gameId, [FromQuery] GetGamePlayerInvitesRequest request)
    {
        BasePaginationRequest<GetGamePlayerInvitesViewModel, GetGamePlayerInvitesFilterDto> query =
            Mapper.Map<GetGamePlayerInvitesQuery>(request)
                  .SetGameId(gameId);

        GetGamePlayerInvitesViewModel result = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetGamePlayerInvitesResponse>(result));
    }
}