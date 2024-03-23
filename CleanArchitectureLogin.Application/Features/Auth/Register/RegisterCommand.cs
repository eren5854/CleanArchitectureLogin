using MediatR;

namespace CleanArchitectureLogin.Application.Features.Auth.Register;
public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password): IRequest<string>;
