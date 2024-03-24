using CleanArchitectureLogin.Domain.Entities;
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


        var userName = request.UserName;
        UserNameValidator userNameValidator = new UserNameValidator();

		bool isUserNameValid = userNameValidator.IsUserNameValid(request.UserName);

        if (!isUserNameValid)
        {
            throw new Exception("Geçerli bir Kullanıcı adı giriniz!");
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


        return "User created successfully";
    }
}
