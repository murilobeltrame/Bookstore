using Bookstore.Api.Authors;
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
            var authorModel = modelBuilder.Entity<Author>();
            authorModel.HasKey(x => x.Id);
            authorModel.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            var bookModel = modelBuilder.Entity<Book>();
            bookModel.HasKey(x => x.Id);
            bookModel.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            bookModel.Property(x => x.Publisher)
                .HasMaxLength(100)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }
    }
}
