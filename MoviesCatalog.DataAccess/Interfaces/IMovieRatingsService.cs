using MoviesCatalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Interfaces
{
    public interface IMovieRatingsService
    {
        public Task<bool> CreateRate(Ratings newRating);
        public Task<bool> DeleteRating(Ratings deleteRating);
        public Task<Ratings> GetRatingByMovieAndUser(int movieId, int userId);
        public Task<List<Ratings>> GetRatingsByUser(int userId);
        public Task<Ratings> GetRatingsById(int ratingId);
    }
}
