using DependencyStore;
using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(x => new SqlConnection("CONN_STR"));
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddTransient<IPromocodeRepository,PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService,DeliveryFeeService>();
builder.Services.AddSingleton<Configuration>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();