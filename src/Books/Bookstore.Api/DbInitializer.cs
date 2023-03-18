using Bookstore.Api.Authors;
using Bookstore.Api.Books;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api
{
    public class DbInitializer
    {
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context) => _context = context;

        public void Run()
        {
            _context.Database.Migrate();

            if (!_context.Books.Any())
            {
                var matinFowler = new Author("Martin Fowler");
                _context.Authors.Add(matinFowler);

                var eip = new Book("Enterprise Integration Patterns: Designing, Building and Deploying Messaging Solutions", "Addison-Wesley Professional", new List<Author> { new Author("Gregor Hohpe"), new Author("Bobby Woolf") });
                var refactoring = new Book("Refactoring: Improving the Design of Existing Code", "Addison-Wesley Professional", new List<Author> { matinFowler });
                var eaa = new Book("Patterns of Enterprise Application Architecture", "Addison-Wesley Professional", new List<Author> { matinFowler });
                var gof = new Book("Design Patterns: Elements of Resuable Object-Oriented Software", "Addison-Wesley Professional", new List<Author> { new Author("Erich Gamma"), new Author("Richard Helm"), new Author("Ralph Johnson"), new Author("John Vlissides") });
                var buildingMicrosservices = new Book("Building Microsservices: Designing Fine-Grained Systems", "O'Reilly Media", new List<Author> { new Author("Sam Newman") });
                var buildingEvolutionaryArchitectures = new Book("Building Evolutionary Architectures: Support Constant Change", "O'Reilly Media", new List<Author> { new Author("Neal Ford"), new Author("Patrick Kua") });
                var livingDoc = new Book("Living Documentation: Continuous Knowledge Sharing by Design", "Addison-Wesley Professional", new List<Author> { new Author("Cyrille Martraire") });
                var sre = new Book("Site Reliability Engineering: How Google Runs Production Systems", "O'Reilly Media", new List<Author> { new Author("Niall Richard Murphy"), new Author("Betsy Beyer") });
                var cd = new Book("Continuous Delivery: Reliable Software Releases Through Build, Test and Deployment Automation", "Addison-Wesley Professional", new List<Author> { new Author("Jez Humble"), new Author("David Farley") });
                var ci = new Book("Continuous Integration: Improving Software Quality and Reducing Risk", "Addison-Wesley Professional", new List<Author> { new Author("Paul Duvall"), new Author("Steve Matyas"), new Author("Andrew Glover") });
                _context.AddRange(new[] { eip, refactoring, eaa, gof, buildingMicrosservices, buildingEvolutionaryArchitectures, livingDoc, sre, cd, ci });

                _context.SaveChanges();
            }
        }
    }
}
