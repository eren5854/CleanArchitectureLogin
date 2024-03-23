using MediatR;

namespace CleanArchitectureLogin.Application.Features.Roles.GetRolesQuery;
public sealed record GetRolesQuery(): IRequest<List<String>>
{
}
