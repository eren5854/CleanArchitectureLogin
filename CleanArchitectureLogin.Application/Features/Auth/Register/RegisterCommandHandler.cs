using CleanArchitectureLogin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CleanArchitectureLogin.Application.Features.Auth.Register;
internal sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<RegisterCommand, string>
{
    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (request.Email is not null)
        {
            bool isEmailExists = await userManager.Users.AnyAsync(p => p.Email == request.Email);
            if (isEmailExists)
            {
                throw new ArgumentException("Bu email kullanılıyor.");
            }

        }

        if (request.UserName is not null)
        {
            Regex userNameRegex = new Regex(@"^(?!.*\s)[a-zA-Z0-9_-]{3,50}$");
            bool isUserNameValid = userNameRegex.IsMatch(request.UserName);
            if (!isUserNameValid)
            {
                throw new ArgumentException("Geçerli bir kullanıcı adı giriniz!");
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

        if (!result.Succeeded)
        {
            List<string> errors = result.Errors.Select(s => s.Description).ToList();
            string errorMessages = string.Join(", ", errors);
            return errorMessages;
        }

        return "User created successfully";
    }
}
