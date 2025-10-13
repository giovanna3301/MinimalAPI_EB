var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Endpoint /health
app.MapGet("/health", () => new { status = "Healthy" });

// Endpoint /hello/{name}
app.MapGet("/hello/{name}", (string name) => new { message = $"Hello, {name}!" });

app.Run();
