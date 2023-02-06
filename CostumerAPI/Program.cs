using CostumerAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Base de datos insercion de dependencias */

var dbHost = "localhost";
var dbName = "dms_costumer";
var dbPassword = "123456";
var connectionString = $"Data Source = {dbHost};Initial Catalog={dbName};User ID=sa; Password={dbPassword}";
builder.Services.AddDbContext<CostumerDbContext>(opt => opt.UseSqlServer(connectionString));

/* ================================================= */

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

app.UseAuthorization();

app.MapControllers();

app.Run();
