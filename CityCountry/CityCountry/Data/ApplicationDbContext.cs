using CityCountry.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityCountry.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>(entity => 
            {
                entity.HasMany(x => x.Cities)
                        .WithOne(x => x.Country);

                entity.HasIndex(x => x.Name).IsUnique();
            });

            builder.Entity<City>(entity => 
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });

            base.OnModelCreating(builder);
        }
    }
}
