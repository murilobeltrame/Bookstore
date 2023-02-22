using System;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api
{
	public class DbInitializer
	{
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
		{
			_context = context;
		}

		public void Run()
		{
			_context.Database.Migrate();
		}
	}
}
