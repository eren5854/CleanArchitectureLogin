using MediatR;

namespace CleanArchitectureLogin.Application.Features.Roles.CreateRole;
public sealed record CreateRoleCommand(
    string Name) : IRequest;

