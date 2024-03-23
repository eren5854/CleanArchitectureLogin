using MediatR;

namespace CleanArchitectureLogin.Application.Features.Roles.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly AppRole _appRole;

    public CreateRoleCommandHandler(AppRole appRole)
    {
        _appRole = appRole;
    }

    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {

        var checkRoleIsExists = await _appRole.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (checkRoleIsExists)
        {
            throw new ArgumentException("Bu rol daha önce oluşturulmuş");
        }

        appRole _appRole = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        return Unit.Value;    
    }
}