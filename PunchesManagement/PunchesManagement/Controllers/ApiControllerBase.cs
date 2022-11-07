using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using System.Net;
using System.Security.Claims;

namespace PunchesManagement.Controllers;

public class ApiControllerBase : ControllerBase
{
	protected readonly IMediator _mediator;
	private readonly ILogger<ApiControllerBase> _logger;

	protected ApiControllerBase(IMediator mediator, ILogger<ApiControllerBase> logger)
	{
		_mediator = mediator;
		_logger = logger;
	}

	protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
		where TRequest : IRequest<TResponse>
		where TResponse : ErrorResponseBase
	{
		if (!this.ModelState.IsValid)
		{
			return this.BadRequest(
				this.ModelState
				.Where(x => x.Value.Errors.Any())
				.Select(x => new
				{
					property = x.Key, errors = x.Value.Errors
				}));
		}

        if (User.Claims.FirstOrDefault() != null)
        {
            (request as RequestBase).AuthenticationIdentifier = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            (request as RequestBase).AuthenticationUserName = User.FindFirstValue(ClaimTypes.Name);
            (request as RequestBase).AuthenticationRole = User.FindFirstValue(ClaimTypes.Role);
        }

        var response = await _mediator.Send(request);
		if (response.Error != null)
		{
            return this.ErrorResponse(response.Error);
		}

		return this.Ok(response);
	}

	private IActionResult ErrorResponse(ErrorModel errorModel)
	{

        _logger.LogError($"We have error: {errorModel.Error}!");
        var httpCode = GetHttpStatusCode(errorModel.Error);
		return StatusCode((int)httpCode, errorModel);
	}

	private static HttpStatusCode GetHttpStatusCode(string errorType)
	{
        switch (errorType)
		{
			case ErrorType.NotFound:
				return HttpStatusCode.NotFound;
            case ErrorType.InternalServerError:
                return HttpStatusCode.InternalServerError;
            case ErrorType.Unauthorized:
                return HttpStatusCode.Unauthorized;
            case ErrorType.RequestTooLarge:
                return HttpStatusCode.RequestEntityTooLarge;
            case ErrorType.UnsupportedMediaType:
                return HttpStatusCode.UnsupportedMediaType;
            case ErrorType.UnsupportedMethod:
                return HttpStatusCode.MethodNotAllowed;
            case ErrorType.TooManyRequests:
                return (HttpStatusCode)429;
			default:
				return HttpStatusCode.BadRequest;
        }
	}
}
