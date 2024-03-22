using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureLogin.Domain.Entity;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string Password { get; set; } = string.Empty;
}
