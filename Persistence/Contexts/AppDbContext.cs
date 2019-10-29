using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieReview.API.Domain.Models;

namespace MovieReview.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().ToTable("Movies");
            builder.Entity<Movie>().HasKey(p => p.MovieId); // Primary Key
            builder.Entity<Movie>().Property(p => p.MovieId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Movie>().Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Movie>().Property(p => p.YearOfRelease).IsRequired();
            builder.Entity<Movie>().Property(p => p.RunningTime).IsRequired();
            builder.Entity<Movie>().Property(p => p.AverageRating);
            builder.Entity<Movie>().Property(p => p.Genre).IsRequired().HasMaxLength(20);

            //builder.Entity<Movie>().HasMany(p => p.Users).WithOne(p => p.Movie).HasForeignKey(p => p.CategoryId);

            builder.Entity<Movie>().HasMany(p => p.Users).WithOne(p => p.Movie).HasForeignKey(p => p.MovieId);


            builder.Entity<Movie>().HasData
            (
                new Movie { MovieId = 1, Title = "Terminator", YearOfRelease=1998, AverageRating=2.91F, Genre=EGenre.Action }, // Id set manually due to in-memory provider
                new Movie { MovieId = 2, Title = "Terminal", YearOfRelease = 1996, AverageRating=3.249F, Genre = EGenre.Drama },
                new Movie { MovieId = 3, Title = "Joker", YearOfRelease=2019, AverageRating = 3.25F, Genre=EGenre.Thriller },
                new Movie { MovieId = 4, Title = "Movie 4", YearOfRelease = 2017, AverageRating = 3.6F, Genre = EGenre.Documentary },
                new Movie { MovieId = 5, Title = "Movie 5", YearOfRelease = 2018, AverageRating = 3.75F, Genre = EGenre.Thriller },

                new Movie { MovieId = 6, Title = "Movie 6", YearOfRelease = 2006, AverageRating = 4.75F, Genre = EGenre.Comedy },
                new Movie { MovieId = 7, Title = "Movie 7", YearOfRelease = 2007, AverageRating = 3.75F, Genre = EGenre.Horror },
                new Movie { MovieId = 8, Title = "Movie 8", YearOfRelease = 2008, AverageRating = 2.75F, Genre = EGenre.Horror },
                new Movie { MovieId = 9, Title = "Movie 9", YearOfRelease = 2009, AverageRating = 1.75F, Genre = EGenre.Comedy },
                new Movie { MovieId = 10, Title = "Movie 10", YearOfRelease = 2010, AverageRating = 2.25F, Genre = EGenre.Action }
            );

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.UserId); // Primary Key
            builder.Entity<User>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.AverageRating).IsRequired();

            builder.Entity<User>().HasData
          (
              new User { UserId = 1, Name = "Bob", AverageRating = 2.57F, MovieId=1 }, // Id set manually due to in-memory provider
              new User { UserId = 2, Name = "Bob", AverageRating = 3.45F, MovieId = 2 },
              new User { UserId = 3, Name = "Don", AverageRating = 3.45F, MovieId = 1 },
              new User { UserId = 4, Name = "Don", AverageRating = 4.00F, MovieId = 2 }
          );

            // Many to many relationshiop between movies and users
            //builder.Entity<MovieUser>().HasKey(mu => new { mu.MovieId, mu.UserId});

        }
    }
}
