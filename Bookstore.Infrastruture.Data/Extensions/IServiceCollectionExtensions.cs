using Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infrastruture.Data.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
		{
			return services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
		}
	}
}

