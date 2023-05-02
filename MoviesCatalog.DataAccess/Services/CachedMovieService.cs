using Microsoft.Extensions.Caching.Memory;
using MoviesCatalog.Core.Helpers;
using MoviesCatalog.Core.Models;
using MoviesCatalog.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Services
{
    internal class CachedMovieService : IMovieService
    {
        private const string MovieListCacheKey = "MovieList";
        private readonly IMemoryCache _memoryCache;
        private readonly IMovieService _movieService;

        public CachedMovieService(IMovieService movieService, IMemoryCache memoryCache)
        {
            _movieService = movieService;
            _memoryCache = memoryCache;
        }


        public Task<Movie> CreateMovie(Movie NewMovie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieCategory>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<MovieCategory> GetCategoryByName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(int MovieId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByName(string movieName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies(PaginationFilter paginationFilter)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(500))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(900));

            if (_memoryCache.TryGetValue(MovieListCacheKey, out IEnumerable<Movie> query))
                return query;

            query = await _movieService.GetMovies(paginationFilter);

            _memoryCache.Set(MovieListCacheKey, query, cacheOptions);

            return query;

        }

        public Task<Movie> UpdateMovie(Movie UpdatedMovie)
        {
            throw new NotImplementedException();
        }
    }
}
