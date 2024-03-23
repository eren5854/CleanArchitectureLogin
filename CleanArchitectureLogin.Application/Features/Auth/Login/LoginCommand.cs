using MediatR;

namespace CleanArchitectureLogin.Application.Features.Auth.Login;
public sealed record LoginCommand(
	string UserNameOrEmail,
	string Password) : IRequest<bool>;




