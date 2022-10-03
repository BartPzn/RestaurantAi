using System;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAi.Entities
{
    
        public class RestaurantDbContext : DbContext
        {
        //?? docker build -f Dockerfile..
        private string _connectionString = "Server=localhost;Database=RestaurantDb;User Id=sa;Password:Docker@123;";

            public DbSet<Restaurant> Restaurants { get; set; }

            public DbSet<Address> Addresses { get; set; }

            public DbSet<Dish> Dishes { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Restaurant>()
                    .Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                modelBuilder.Entity<Dish>()
                    .Property(d => d.Name)
                    .IsRequired();

            }

           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           {
               optionsBuilder.UseSqlServer(_connectionString);
           }
        }
    

}


