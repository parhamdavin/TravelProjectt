
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using BaretProject.Application.Contracts;
using BaretProject.Application.MiddleWare;
using BaretProject.Persistence.Infrat.Extension;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicationServices(builder.Configuration);


builder.Host.UseSerilog(((context, provider, logger) =>
{
    logger.MinimumLevel.Information().WriteTo.File("log.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error
    ).WriteTo.File(new RenderedCompactJsonFormatter(), "log.ndjson", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning);
}));

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
