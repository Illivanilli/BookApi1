using System;
using CS321_W3D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CS321_W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> books { get; set; }

        // This method runs once when the DbContext is first used.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Book.db");

        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Catcher in the Rye", Author = "J.D Salinger", Category = "Coming of Age" },
            new Book { Id = 2, Title = "Lord Of the The Rings: FellowShip of the Ring", Author = "J.R.R Tolkien", Category = "Fantasy" }
            );
        }

    }
}

