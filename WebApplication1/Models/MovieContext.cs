using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = "A", Name = "Action" },
                 new Genre { GenreID = "B", Name = "Comedy" },
                  new Genre { GenreID = "C", Name = "Drama" },
                   new Genre { GenreID = "D", Name = "Horro" },
                    new Genre { GenreID = "E", Name = "Musical" },
                     new Genre { GenreID = "F", Name = "RomCom" },
                      new Genre { GenreID = "G", Name = "SciFi" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieID = 10,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreID = "D"
                },
                 new Movie
                 {
                     MovieID = 11,
                     Name = "Casabxxlanca",
                     Year = 1942,
                     Rating = 5,
                     GenreID = "C"
                 },
                  new Movie
                  {
                      MovieID = 12,
                      Name = "Casablancauu",
                      Year = 1942,
                      Rating = 5,
                      GenreID = "E"
                  }
                );

        }
    }
}
