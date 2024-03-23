using CleanArchitectureLogin.Application;
using CleanArchitectureLogin.Domain.Entities;
using CleanArchitectureLogin.Infrastructure;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();




using (var scoped = app.Services.CreateScope())
{
	var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
	if (!userManager.Users.Any())
	{
		userManager.CreateAsync(new AppUser
		{
			UserName = "MCUnaldi",
			Email = "MCUnaldi@gmail.com",
			UserRole = 0,
			Id = Guid.NewGuid(),
			FirstName = "MCU",
			LastName = "Ünaldý",
		}, "Password123*").Wait();
	}
}




app.Run();
