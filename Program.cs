using MinimalApiDemo.Models;  // <- to jest ważne!

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoint /
app.MapGet("/", () => "Hello World!");

// Endpoint /health
app.MapGet("/health", () => new { status = "Healthy" });

// Endpoint /hello/{name}
app.MapGet("/hello/{name}", (string name) => new { message = $"Hello, {name}!" });

// Endpoint /user
app.MapGet("/user", () =>
{
    var user = new User { Id = 1, Username = "Eryk", Email = "eryk@example.com" };
    return user;
});

app.Run();
