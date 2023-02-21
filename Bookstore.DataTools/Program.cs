// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Reflection;
using Bookstore.Api;
using Bookstore.DataTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, service) =>
    {
        var connectionString = context.Configuration["ConnectionStrings:bookstore-db"];
        var migrationAssembly = Assembly.GetExecutingAssembly().FullName;

        service.AddDbContext<ApplicationContext>(o => o.UseNpgsql(connectionString, x => x.MigrationsAssembly(migrationAssembly)));

        service.AddHostedService<MigrateTask>();
    })
    .Build()
    .RunAsync();