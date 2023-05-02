using MoviesCatalog.Core.Helpers;
using MoviesCatalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Interfaces
{
    public interface IMovieService
    {
        public Task<Movie> CreateMovie(Movie NewMovie);
        public Task<bool> DeleteMovie(Movie Movie);
        public Task<Movie> UpdateMovie(Movie UpdatedMovie);
        public Task<IEnumerable<Movie>> GetMovies(PaginationFilter paginationFilter);
        public Task<Movie> GetMovieByName(string movieName);
        public Task<Movie> GetMovieById(int MovieId);
        public Task<MovieCategory> GetCategoryByName(string categoryName);
        public Task<List<MovieCategory>> GetAllCategories();

    }
}
