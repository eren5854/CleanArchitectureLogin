using CleanArchitectureLogin.Application.Features.Roles.CreateRole;
using CleanArchitectureLogin.Application.Features.Roles.GetRolesQuery;
using CleanArchitectureLogin.WebAPI.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureLogin.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RolesController : ApiController
{
	public RolesController(IMediator mediattor) : base(mediattor)
	{
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
	{
		await _mediattor.Send(request, cancellationToken);


		return NoContent();
	}
	[HttpPost]
	public async Task<IActionResult> GetAll(GetRolesQuery request, CancellationToken cancellationToken)
	{
		var response = await _mediattor.Send(request, cancellationToken);


		return Ok(response);
	}
}
}
