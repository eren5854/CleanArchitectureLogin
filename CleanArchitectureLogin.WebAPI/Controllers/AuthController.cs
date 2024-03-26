using CleanArchitectureLogin.Application.Features.Auth.Login;
using CleanArchitectureLogin.Application.Features.Auth.Register;
using CleanArchitectureLogin.WebAPI.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureLogin.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
