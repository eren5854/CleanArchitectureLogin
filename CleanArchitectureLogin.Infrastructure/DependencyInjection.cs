using CleanArchitectureLogin.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System;
using CleanArchitectureLogin.Domain.Entities;

namespace CleanArchitectureLogin.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
		services.AddIdentity<AppUser, AppRole>(options =>
		{
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireDigit = false;
			options.Password.RequiredLength = 1;
			options.Password.RequireUppercase = false;
			options.Password.RequireLowercase = false;

		}).AddEntityFrameworkStores<ApplicationDbContext>();

		return services;
    }
}
