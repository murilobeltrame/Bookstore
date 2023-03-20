using Bookstore.GraphQl;
using Bookstore.GraphQl.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
var bookClientConnectionString = configuration.GetConnectionString("books-api");
builder.Services.AddHttpClient<BooksClient>(o => o.BaseAddress = new Uri(bookClientConnectionString!));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapGraphQL(path: string.Empty);

app.Run();
