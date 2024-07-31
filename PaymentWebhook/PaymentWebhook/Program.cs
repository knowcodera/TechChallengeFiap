using Application.Services;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IPaymentUseCase, PaymentUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://*:8480");
