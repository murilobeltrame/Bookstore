using Bookstore.Api.Books;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Api
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bookModel = modelBuilder.Entity<Book>();

            bookModel.HasKey(x => x.Id);
            bookModel.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            bookModel.Property(x => x.AuthorName)
                .HasMaxLength(100)
                .IsRequired();
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
