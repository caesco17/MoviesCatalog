using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MovieCategory>().HasData(
                new MovieCategory { MovieCategoryId = 1 ,Name = "Action" },
                new MovieCategory { MovieCategoryId = 2, Name = "Comedy" },
                new MovieCategory { MovieCategoryId = 3, Name = "Drama" },
                new MovieCategory { MovieCategoryId = 4, Name = "Fantasy" },
                new MovieCategory { MovieCategoryId = 5, Name = "Horror" }
            );

            modelBuilder.Entity<AccountRole>().HasData(
                new AccountRole { AccountRoleId =1  ,Name = "User" },
                new AccountRole { AccountRoleId = 2 ,Name = "Admin" }
            );

            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount { AccountId=1 ,Email = "user@gmail.com", Password= "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", Name="User npc", AccountRoleId=1 },
                new UserAccount { AccountId=2 ,Email = "admin@gmail.com", Password = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", Name = "Admin npc", AccountRoleId = 2 }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Name = "Goal!", ReleaseYear = 2006, MovieCategoryId = 1, CreatedDate = DateTime.Now, CreatedByAccountId = 2, Synapsis = "Pelicula de deportes." },
                new Movie { MovieId = 2, Name = "El padrino", ReleaseYear = 1972, MovieCategoryId = 2, CreatedDate = DateTime.Now, CreatedByAccountId = 2, Synapsis = "Pelicula de mafiosos." },
                new Movie { MovieId = 3, Name = "Iron Man", ReleaseYear = 2008, MovieCategoryId = 3, CreatedDate = DateTime.Now, CreatedByAccountId = 1, Synapsis = "Pelicula de ciencia ficcion." },
                new Movie { MovieId = 4, Name = "Parásitos", ReleaseYear = 2019, MovieCategoryId = 4, CreatedDate = DateTime.Now, CreatedByAccountId = 1, Synapsis = "Pelicula japonesa." },
                new Movie { MovieId = 5, Name = "Los Cazafantasmas", ReleaseYear = 1984, MovieCategoryId = 5, CreatedDate = DateTime.Now, CreatedByAccountId = 1, Synapsis = "Pelicula Clasica americana" }
            );
        }
    }
}
