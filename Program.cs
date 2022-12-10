using GeoPet.Services;
using GeoPet.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IGeoPetService, GeoPetService>();
builder.Services.AddDbContext<GeoPetContext>();
builder.Services.AddScoped<IGeoPetContext, GeoPetContext>();
builder.Services.AddScoped<IGeoPetRepository, GeoPetRepositorys>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }