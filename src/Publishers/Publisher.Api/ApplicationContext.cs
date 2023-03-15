using Microsoft.EntityFrameworkCore;

namespace Publisher.Api
{
    public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) :
			base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var publisherModel = modelBuilder.Entity<Publisher>();
            publisherModel.HasKey(x => x.Id);
            publisherModel.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Publisher> Publishers { get; set; }
    }
}

