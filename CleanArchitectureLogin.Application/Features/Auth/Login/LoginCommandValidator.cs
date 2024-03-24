using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureLogin.Application.Features.Auth.Login;
public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
	public LoginCommandValidator()
	{
		RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
		RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı boş olamaz");
		RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
		RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
	}
}

/**
  
 
  
								+ loginCommand 
								+ loginCommandHandler
								+ loginCommandValidator
								+ registerCommandValidator
								+ createRoleCommand
								+ createRoleCommandHandler
								+ getRolesQuery
                                + appRole
                                + apiController
                                + AuthController
                                + RolesController
 
 
 
 
 **/
