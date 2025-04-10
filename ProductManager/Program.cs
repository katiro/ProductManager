using Microsoft.EntityFrameworkCore;
using ProductManager.Model;
using ProductManager.Repository;
using ProductManager.Repository.Interface;
using ProductManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Capa de servicios
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

// SqlServer Services
builder.Services.AddDbContext<ProductManagerDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagerDBContext")));

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
