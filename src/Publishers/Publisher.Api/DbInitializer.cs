using Microsoft.EntityFrameworkCore;

namespace Publisher.Api
{
    public class DbInitializer
	{
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context) => _context = context;

        public void Run()
        {
            _context.Database.Migrate();

            if (!_context.Publishers.Any())
            {
                var addison = new Publisher("Addison-Wesley Professional", "United States", "Boston");
                var oreilly = new Publisher("O'Reilly Media", "United States", "Sebastopol, California");
                _context.AddRange(new[] { addison, oreilly });
                _context.SaveChanges(); 
            }
        }
	}
}
