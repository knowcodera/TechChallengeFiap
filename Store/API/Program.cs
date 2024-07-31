

using Application.Mappings;
using Application.UseCases;
using Domain.Interfaces;
using Infra;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var server = builder.Configuration["DBServer"] ?? "sqlserver";
var port = builder.Configuration["DBPort"] ?? "1433";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "PA55w0rd2024";
var database = builder.Configuration["Database"] ?? "Fiap";

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};TrustServerCertificate=true"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IClientUseCase, ClientUseCase>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();

builder.Services.AddTransient<IProductUseCase, ProductUseCase>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ICategoryUseCase, CategoryUseCase>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IOrderUseCase, OrderUseCase>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IPaymentUseCase, PaymentUseCase>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FiapTech",
        Version = "v1",
        Description = "Tech",
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDB.PrepPopulation(app);

app.Run();
