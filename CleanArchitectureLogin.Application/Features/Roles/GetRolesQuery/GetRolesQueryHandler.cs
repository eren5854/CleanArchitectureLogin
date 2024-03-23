using MediatR;

namespace CleanArchitectureLogin.Application.Features.Roles.GetRolesQuery;

internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery>
{
	private readonly AppRole _approle;

	public GetRolesQueryHandler(AppRole appRole)
	{
		_approle = appRole;
	}

	public async Task Handle(GetRolesQuery request, CancellationToken cancellationToken)
	{
		var response =
		   await _approle.GetAll()
		   .ToListAsync(cancellationToken);


		return response;
	}
]