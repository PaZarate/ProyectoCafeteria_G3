using Microsoft.EntityFrameworkCore;
using ProductAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*Database Context Dependency Injection */

var dbHost = "localhost";
var dbName = "dms_product";
var dbPassword = "P@assw0rd";

var connectionString = $"server ={dbHost};port=3306:database={dbName};user=root;password={dbPassword}";
builder.Services.AddDbContext<ProductDbContext>(o => o.UseMySQL(connectionString));
/* =========================================== */
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
