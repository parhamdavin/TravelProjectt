
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using BaretProject.Application.Contracts;
using BaretProject.Application.MiddleWare;
using BaretProject.Persistence.Infrat.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.ConfigureRequestPipeline();
app.Run();
