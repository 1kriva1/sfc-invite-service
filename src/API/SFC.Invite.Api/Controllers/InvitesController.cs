using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invites.Create;
using SFC.Invite.Api.Infrastructure.Models.Invites.Find;
using SFC.Invite.Api.Infrastructure.Models.Invites.Get;
using SFC.Invite.Api.Infrastructure.Models.Invites.Update;
using SFC.Invite.Api.Infrastructure.Models.Pagination;
using SFC.Invite.Application.Features.Common.Base;
using SFC.Invite.Application.Features.Invite.Commands.Create;
using SFC.Invite.Application.Features.Invite.Commands.Update;
using SFC.Invite.Application.Features.Invite.Queries.Find;
using SFC.Invite.Application.Features.Invite.Queries.Find.Dto.Filters;
using SFC.Invite.Application.Features.Invite.Queries.Get;
using SFC.Invite.Infrastructure.Constants;

namespace SFC.Invite.Api.Controllers;

[Tags("Invites")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class InvitesController : ApiControllerBase
{
    /// <summary>
    /// Create new invite.
    /// </summary>
    /// <param name="request">Create invite request.</param>
    /// <returns>An ActionResult of type CreateInviteResponse</returns>
    /// <response code="201">Returns **new** created invite.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateInviteResponse>> CreateInviteAsync([FromBody] CreateInviteRequest request)
    {
        CreateInviteCommand command = Mapper.Map<CreateInviteCommand>(request);

        CreateInviteViewModel model = await Mediator.Send(command).ConfigureAwait(false);

        return CreatedAtRoute("GetInvite", new { id = model.Invite.Id }, Mapper.Map<CreateInviteResponse>(model));
    }

    /// <summary>
    /// Update existing invite.
    /// </summary>
    /// <param name="id">Invite unique identifier.</param>
    /// <param name="request">Update invite request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if invite updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpPut("{id}")]
    [Authorize(Policy.OwnInvite)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateInviteAsync([FromRoute] long id, [FromBody] UpdateInviteRequest request)
    {
        UpdateInviteCommand command = Mapper.Map<UpdateInviteCommand>(request)
                                                     .SetInviteId(id);

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return invite model by unique identifier.
    /// </summary>
    /// <param name="id">Invite unique identifier.</param>
    /// <returns>An ActionResult of type GetInviteResponse</returns>
    /// <response code="200">Returns invite model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when invite **not found** by unique identifier.</response>
    [HttpGet("{id}", Name = "GetInvite")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetInviteResponse>> GetInviteAsync([FromRoute] long id)
    {
        GetInviteQuery query = new() { InviteId = id };

        GetInviteViewModel invite = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetInviteResponse>(invite));
    }

    /// <summary>
    /// Return list of invitemultiple
    /// </summary>
    /// <param name="request">Get invitemultiple request.</param>
    /// <returns>An ActionResult of type GetInvitesResponse</returns>
    /// <response code="200">Returns list of invitemultiple with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetInvitesResponse>> GetInvitesAsync([FromQuery] GetInvitesRequest request)
    {
        BasePaginationRequest<GetInvitesViewModel, GetInvitesFilterDto> query = Mapper.Map<GetInvitesQuery>(request);

        GetInvitesViewModel result = await Mediator.Send(query).ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetInvitesResponse>(result));
    }
}
