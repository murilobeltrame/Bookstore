using Bookstore.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore.Tests.Api;

public class BookApi : IClassFixture<WebApplicationFactory<Program>>
{
    // [Fact]
    // public async void GetExistingBookShouldReturnABook()
    // {
    //     using var host = await new HostBuilder()
    //         .ConfigureWebHost(c =>
    //         {
    //             c.UseTestServer().Configure(a => { });
    //         })
    //         .StartAsync();

    //     var client = host.GetTestClient();

    //     var response = await client.GetAsync("/books");

    //     response.EnsureSuccessStatusCode();

    // }
}
