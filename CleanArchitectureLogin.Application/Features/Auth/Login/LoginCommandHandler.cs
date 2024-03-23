using CleanArchitectureLogin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureLogin.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
	private readonly UserManager<AppUser> _userManager;

	public LoginCommandHandler(UserManager<AppUser> userManager)
	{
		_userManager = userManager;
	}

	public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
	{
		AppUser? appUser = await _userManager.Users.SingleOrDefaultAsync(p => p.UserName == request.UserNameOrEmail.ToUpper() ||
			p.Email == request.UserNameOrEmail.ToUpper(), cancellationToken);

		if (appUser == null)
		{
			throw new ArgumentException("Kullanıcı Bulunamadı!");
		}

		bool checkPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);
		return checkPassword;
	}
}




