using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Core.Models;
using MoviesCatalog.DataAccess.Data;
using MoviesCatalog.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Services
{
    public class MovieRatingsService : IMovieRatingsService
    {
        private readonly DataContext _dataContext;
        public MovieRatingsService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<bool> CreateRate(Ratings newRating)
        {
            _dataContext.Ratings.Add(newRating);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRating(Ratings deleteRating)
        {
            _dataContext.Ratings.Remove(deleteRating);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<Ratings> GetRatingByMovieAndUser(int movieId, int userId)
        {
            var rating = await _dataContext.Ratings.Where(a => a.RatedMovie.MovieId == movieId && a.RatedBy.AccountId == userId).FirstOrDefaultAsync();

            return rating;
        }

        public async Task<Ratings> GetRatingsById(int ratingId)
        {
            var rating = await _dataContext.Ratings.Where(a => a.RatingId == ratingId).FirstOrDefaultAsync();

            return rating;
        }

        public async Task<List<Ratings>> GetRatingsByUser(int userId)
        {
            var ratings = await _dataContext.Ratings.Where(a => a.RatedBy.AccountId == userId).ToListAsync();

            return ratings;
        }
    }
}
