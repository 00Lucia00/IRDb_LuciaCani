using IRDb_LuciaCani.Data;
using IRDb_LuciaCani.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// found in appsettings
var connString = builder.Configuration.GetConnectionString("IRDbConnection");
builder.Services.AddDbContext<IRDbContext>(options => options.UseMySql(connString, ServerVersion.AutoDetect(connString)));

builder.Services.AddScoped<IMovieRepos, MovieRepos>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
