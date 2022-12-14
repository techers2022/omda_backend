using OMDA.Configurations;
using OMDA.Services;
using OMDA.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConnectionSettings>(builder.Configuration.GetSection("Database"));
builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));

builder.Services.AddSingleton<TwilioService>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<WorksService>();

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

app.MapUserEndpoints();
app.MapLoginEndpoint();
app.MapRegisterEndpoint();
app.MapCreateWorkEndpoint();
app.MapGetWorkDetailedEndpoint();
app.MapGetWorksFromUserEndpoint();
app.MapGetWorksAcceptedByUserEndpoint();
app.MapGetAllWorksEndpoint();
app.MapAcceptWorkEndpoint();
app.MapUpdateUserEndpoint();

app.Run();