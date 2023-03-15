using System.Reflection;
using Bookstore.Api;
using Bookstore.Api.Shared.Midlewares;
using Bookstore.CQRS;
using Bookstore.CQRS.Interfaces;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(configuration.GetConnectionString("bookstore-db")));
builder.Services.AddMassTransit(o => o.UsingRabbitMq((context, config) =>
{
    config.Host(configuration.GetConnectionString("bookstore-broker", "protocol"));
}));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<DbInitializer>().Run();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.RoutePrefix = string.Empty;
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

// REQUIRED FOR TESTS
public partial class Program { }