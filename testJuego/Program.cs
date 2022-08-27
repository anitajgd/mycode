using System.Reflection;
using MediatR;
using Microsoft.OpenApi.Models;
using testJuego.Application.Commands;
using testJuego.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Commands
builder.Services.AddMediatR(typeof(CreatePlayerCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(PlayCommand).GetTypeInfo().Assembly);

// Queries
builder.Services.AddMediatR(typeof(GetValueDice).GetTypeInfo().Assembly);

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
