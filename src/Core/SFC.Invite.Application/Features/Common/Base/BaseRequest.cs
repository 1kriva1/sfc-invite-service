using MediatR;

using Microsoft.Extensions.Logging;

using SFC.Invite.Application.Common.Enums;

namespace SFC.Invite.Application.Features.Common.Base;

/// <summary>
/// Base MediatR request. 
/// </summary>
public abstract class BaseRequest
{
    public abstract RequestId RequestId { get; }

    public EventId EventId => new((int)RequestId, Enum.GetName(RequestId));
}

/// <summary>
/// Parent MediatR request. 
/// </summary>
public abstract class Request : BaseRequest, IRequest { }

/// <summary>
/// Parent MediatR request with response. 
/// </summary>
public abstract class Request<TResponse> : BaseRequest, IRequest<TResponse> { }