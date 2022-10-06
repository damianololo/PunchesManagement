﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using PunchesManagement.ApplicationServices.API.Domain;

namespace PunchesManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class PunchesController : ControllerBase
{
	private readonly IMediator _mediator;

	public PunchesController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[Route ("")]
	public async Task<IActionResult> GetAllPunches([FromQuery]GetPunchesRequest request)
	{
		var response = await _mediator.Send(request);

		return Ok(response);
	}
}