using CleanArchitectureLogin.Application.Features.Auth.Login;
using CleanArchitectureLogin.Application.Features.Auth.Register;
using CleanArchitectureLogin.WebAPI.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureLogin.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ApiController
{
	private readonly IMediator _mediator;

	public AuthController(IMediator mediator) : base(mediator)
	{
		_mediator = mediator;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
	{
		await _mediator.Send(request, cancellationToken);
		return Ok("Kayıt Oluşturuldu!");
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
	{
		bool loginSuccessful = await _mediator.Send(request, cancellationToken);

		if (loginSuccessful)
		{
			return Ok("Giriş başarılı");
		}
		else
		{
			return Ok("Kullanıcı adı veya şifre yanlış"); // değişebilirrr
		}
	}
}
