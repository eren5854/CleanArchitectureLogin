using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureLogin.Domain.Entity;
public sealed class AppUser : IdentityUser<Guid>
{
}
