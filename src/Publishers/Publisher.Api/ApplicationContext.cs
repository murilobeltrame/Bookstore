﻿using Bookstore.CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Publisher.Api
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var publisherModel = modelBuilder.Entity<Publisher>();
            publisherModel.HasKey(x => x.Id);
            publisherModel.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            publisherModel.Property(x => x.OriginCountry)
                .HasMaxLength(50)
                .IsRequired();
            publisherModel.Property(x => x.HeadquartersLocation)
                .HasMaxLength(100)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Publisher> Publishers { get; set; }
    }
}
