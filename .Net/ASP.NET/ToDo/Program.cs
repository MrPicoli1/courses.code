using ToDo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();


app.MapControllers();


app.UseSwagger();
app.UseSwaggerUI();




app.UseHttpsRedirection();


app.Run();

