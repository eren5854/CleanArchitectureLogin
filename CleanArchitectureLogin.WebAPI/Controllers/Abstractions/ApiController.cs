using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureLogin.WebAPI.Controllers.Abstractions;
[Route("api/[controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
	public readonly IMediator _mediattor;

	protected ApiController(IMediator mediattor)
	{
		_mediattor = mediattor;
	}
}
