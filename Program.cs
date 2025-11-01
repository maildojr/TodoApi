using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Core.Repositories;
using Microsoft.OpenApi.Models;
using TodoApi.Core.UseCases;
using TodoApi.Core.Interfaces;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure MySQL
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionString = $"Server={Env.GetString("DB_SERVER")};" +
                    $"Port={Env.GetString("DB_PORT")};" +
                    $"Database={Env.GetString("DB_NAME")};" +
                    $"Uid={Env.GetString("DB_USER")};" +
                    $"Pwd={Env.GetString("DB_PASSWORD")}";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Dependency Injection
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoUseCases, TodoUseCases>(); 

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();