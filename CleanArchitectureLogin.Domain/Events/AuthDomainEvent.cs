using CleanArchitectureLogin.Domain.Entities;
using MediatR;

namespace CleanArchitectureLogin.Domain.Events;
public sealed class AuthDomainEvent : INotification
{
    public readonly AppUser _appUser;

    public AuthDomainEvent(AppUser appUser)
    {
        _appUser = appUser;
    }
}
