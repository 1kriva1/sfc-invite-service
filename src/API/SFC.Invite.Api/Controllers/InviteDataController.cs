using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Api.Infrastructure.Models.Invite.Data.GetAll;
using SFC.Invite.Application.Features.Invite.Data.Queries.GetAll;
using SFC.Invite.Infrastructure.Constants;

namespace SFC.Invite.Api.Controllers;

[Tags("Data Invites")]
[Route("api/Invites/Data")]
[Authorize(Policy.General)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
public class InviteDataController : ApiControllerBase
{
    /// <summary>
    /// Return all available data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllInviteDataResponse>> GetAllAsync()
    {
        GetAllInviteDataQuery query = new();

        GetAllInviteDataViewModel model = await Mediator.Send(query).ConfigureAwait(true);

        return Ok(Mapper.Map<GetAllInviteDataResponse>(model));
    }
}