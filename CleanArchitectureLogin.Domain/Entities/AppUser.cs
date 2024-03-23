using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureLogin.Domain.Entities;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
}
