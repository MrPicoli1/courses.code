using DependencyStore;
using DependencyStore.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("");
builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSingleton<Configuration>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();