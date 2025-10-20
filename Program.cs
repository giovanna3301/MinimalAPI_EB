using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja EF Core InMemory
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UsersDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", () => new { status = "Healthy" });

app.MapGet("/hello/{name}", (string name) => new { message = $"Hello, {name}!" });

app.MapGet("/user", () =>
{
    var user = new User { Id = 1, Username = "Eryk", Email = "eryk@example.com" };
    return user;
});

// POST /users
app.MapPost("/users", async (User user, AppDbContext db) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

// GET /users
app.MapGet("/users", async (AppDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return Results.Ok(users);
});

app.Run();
