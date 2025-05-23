using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Create;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Find;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Get;
using SFC.Invite.Api.Infrastructure.Models.Invite.Team.Player.Update.Refuse;
using SFC.Invite.Api.Infrastructure.Models.Pagination;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Create;
using SFC.Invite.Application.Features.Invite.Team.Player.Commands.Update;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Find.Dto.Filters;
using SFC.Invite.Application.Features.Invite.Team.Player.Queries.Get;
using SFC.Invite.Infrastructure.Constants;

namespace SFC.Invite.Api.Controllers;

/// <summary>
/// Team player invite controller:
/// - create invite
/// - cancel/accept/refuse invite
/// - get/find invites
/// </summary>
[Tags("Team Player Invites")]
[Route("api/Invites")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class TeamPlayerInvitesController : ApiControllerBase
{
    /// <summary>
    /// Create new team invite for player.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="request">Create team invite for player request.</param>
    /// <returns>An ActionResult of type CreateTeamPlayerInviteResponse</returns>
    /// <response code="201">Returns **new** created team player invite.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Teams/{teamId}/Players/{playerId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateTeamPlayerInviteResponse>> CreateTeamPlayerInviteAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromBody] CreateTeamPlayerInviteRequest request)
    {
        CreateTeamPlayerInviteCommand command = Mapper.Map<CreateTeamPlayerInviteCommand>(request)
                                                      .SetTeamId(teamId)
                                                      .SetPlayerId(playerId);

        CreateTeamPlayerInviteViewModel model = await Mediator.Send(command)
                                                              .ConfigureAwait(false);

        return CreatedAtRoute("GetTeamPlayerInvite",
            new { teamId = model.Invite.TeamId, playerId = model.Invite.Player.Id, inviteId = model.Invite.Id },
            Mapper.Map<CreateTeamPlayerInviteResponse>(model));
    }

    /// <summary>
    /// Cancel team invite for player by team.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Team player invite Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** canceled.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Teams/{teamId}/Players/{playerId}/Cancel")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelTeamPlayerInviteAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long inviteId)
    {
        UpdateTeamPlayerInviteCommand command = InviteStatusEnum.Canceled
            .BuildUpdateTeamPlayerInviteCommand(inviteId, teamId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Refuse team invite for player by player.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Team player invite Id.</param>
    /// <param name="request">Refuse team invite for player request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** refused.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Teams/{teamId}/Players/{playerId}/Refuse")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> RefuseTeamPlayerInviteAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long inviteId, [FromBody] RefuseTeamPlayerInviteRequest request)
    {
        UpdateTeamPlayerInviteCommand command = Mapper.Map<UpdateTeamPlayerInviteCommand>(request)
                                                      .SetId(inviteId)
                                                      .SetTeamId(teamId)
                                                      .SetPlayerId(playerId)
                                                      .SetStatus(InviteStatusEnum.Refused);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Accept team invite for player by player.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Team player invite Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite **successfully** accepted.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{inviteId}/Teams/{teamId}/Players/{playerId}/Accept")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AcceptTeamPlayerInviteAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long inviteId)
    {
        UpdateTeamPlayerInviteCommand command = InviteStatusEnum.Accepted
            .BuildUpdateTeamPlayerInviteCommand(inviteId, teamId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return team invite for player.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="inviteId">Team player invite Id.</param>
    /// <returns>An ActionResult of type GetTeamPlayerInviteResponse</returns>
    /// <response code="200">Returns team invite for player model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when invite **not found**.</response>
    [HttpGet("{inviteId}/Teams/{teamId}/Players/{playerId}", Name = "GetTeamPlayerInvite")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetTeamPlayerInviteResponse>> GetTeamPlayerInviteAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long inviteId)
    {
        GetTeamPlayerInviteQuery query = new() { Id = inviteId, TeamId = teamId, PlayerId = playerId };

        GetTeamPlayerInviteViewModel invite = await Mediator.Send(query)
                                                            .ConfigureAwait(false);

        return Ok(Mapper.Map<GetTeamPlayerInviteResponse>(invite));
    }

    /// <summary>
    /// Return list of team player invites.
    /// </summary>
    /// <param name="request">Get team player invites request.</param>
    /// <returns>An ActionResult of type GetTeamPlayerInvitesResponse</returns>
    /// <response code="200">Returns list of team player invites with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Teams/Players/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetTeamPlayerInvitesResponse>> GetTeamPlayerInvitesAsync([FromQuery] GetTeamPlayerInvitesRequest request)
    {
        BasePaginationRequest<GetTeamPlayerInvitesViewModel, GetTeamPlayerInvitesFilterDto> query = Mapper.Map<GetTeamPlayerInvitesQuery>(request);

        GetTeamPlayerInvitesViewModel result = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetTeamPlayerInvitesResponse>(result));
    }
}