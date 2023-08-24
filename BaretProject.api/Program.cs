
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using BaretProject.Application.Contracts;
using BaretProject.Application.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext
builder.Services.AddDbContextPool<IApplicationContext, SqlServerContext>((options) =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=DB_name;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
}, poolSize: 16);
#endregion

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

app.UseExceptionHandler(app =>
{
    app.UseMiddleware<ErrorHandlerMiddleware>();
});
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
