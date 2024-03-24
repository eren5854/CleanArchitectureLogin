using CleanArchitectureLogin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureLogin.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly UserManager<AppUser> _userManager;

    public LoginCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _userManager.Users.SingleOrDefaultAsync(p => p.UserName == request.UserNameOrEmail.ToUpper() ||
            p.Email == request.UserNameOrEmail.ToUpper(), cancellationToken);

        if (appUser is null)
        {
            throw new ArgumentException("Kullanıcı Bulunamadı!");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);
        if (!checkPassword)
        {
            throw new ArgumentException("Hatalı şifre");
        }
        return "Giriş işlemi başarılı";
    }
}




