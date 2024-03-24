using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitectureLogin.Application.Features.Auth.Register;
public class UserNameValidator
{
public bool IsUserNameValid(string userName)
{
	Regex userNameRegex = new Regex(@"^(?!.*\s)[a-zA-Z0-9_-]{3,50}$");

	return userNameRegex.IsMatch(userName);
}

}
