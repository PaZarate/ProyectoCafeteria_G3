using CostumerAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Base de datos insercion de dependencias SQL server

var dbHost = "localhost";
var dbName = "dms_costumer";
var dbPassword = "";
var connectionString = $"Data Source = {dbHost};Initial Catalog={dbName};User ID=SQLEXPRESS; Password={dbPassword}";
builder.Services.AddDbContext<CostumerDbContext>(opt => opt.UseSqlServer(connectionString)); */

/* Base de datos insercion de dependencias MySQL*/

var dbHost = "localhost";
var dbName = "dms_costumer";
var dbPassword = "";
var connectionString = $"server= {dbHost};port=3306;database={dbName};user=root; Password={dbPassword}";
builder.Services.AddDbContext<CostumerDbContext>(o => o.UseMySQL(connectionString));

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
