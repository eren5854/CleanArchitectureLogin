using CleanArchitectureLogin.Domain.Entities;
using CleanArchitectureLogin.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureLogin.Application.Features.Auth.Register;
internal sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMediator mediator) : IRequestHandler<RegisterCommand, string>
{
    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if(request.Email is not null)
        {
            bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email);
            if(isEmailExists)
            {
                return "Email already has taken";
            }
        }
        AppUser user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName,
        };

        IdentityResult result = await userManager.CreateAsync(user, request.Password);

        if(!result.Succeeded)
        {
            List<string> errors = result.Errors.Select(s => s.Description).ToList();
            string errorMessages = string.Join(", ", errors);
            return errorMessages;
        }

        await mediator.Publish(new AuthDomainEvent(user));

        return "User created successfully";
    }
}
