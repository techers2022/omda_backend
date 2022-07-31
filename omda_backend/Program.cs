using UserStoreApi.Models;
using UserStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<UserStoreDatabaseSettings>(builder.Configuration.GetSection("UserStoreDatabase"));
builder.Services.AddSingleton<UsersService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/users", async (UsersService usersService) =>
{
    var users = await usersService.GetAsync();
    return Results.Ok(users);
});

app.MapGet("/users/{id:length(24)}", async (string id, UsersService usersService) =>
{
    var user = await usersService.GetAsync(id);
    return user is not null ? Results.Ok(user) : Results.NotFound();
});

app.MapPost("/users", async (User user, UsersService usersService) =>
{
    await usersService.CreateAsync(user);
    return Results.Created($"/users/{user.Id}", user);
});

app.Run();