using BubberDinner.Application.Services.Authentication;
using BubberDinner.Application;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    //use dependency Injection
    //builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services
    .AddApplication()
    .AddInfrastructure();
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
