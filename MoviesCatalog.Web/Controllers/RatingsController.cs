using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Core.Helpers;
using MoviesCatalog.Core.Models;
using MoviesCatalog.DataAccess.Interfaces;
using MoviesCatalog.Web.Auth;
using MoviesCatalog.Web.Models;
using System.Net;
using System.Security.Claims;

namespace MoviesCatalog.Web.Controllers
{
    [Route("Ratings")]
    public class RatingsController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IMovieRatingsService _movieRatingsService;
        private readonly IMovieService _movieService;

        public RatingsController(IUserAccountService userAccountService, IMovieRatingsService movieRatingsService, IMovieService movieService) {
            this._userAccountService = userAccountService;
            this._movieRatingsService = movieRatingsService;
            this._movieService = movieService;
        }

        [HttpPost]
        [Authorize(Policy = RoleConstant.MOVIE_USER_ROLE)]
        public async Task<IActionResult> CreateRate([FromQuery] int id, int rate)
        {

            if (rate <= 0)
                return BadRequest("Invalid rating value.");

            //Get Movie
            var movie = await _movieService.GetMovieById(id);

            if(movie == null)
                return BadRequest("Movie does not exist.");

            //Get User
            int userId = GetUserClaims.getUserIDFromClaims(HttpContext.User.Identity as ClaimsIdentity);
            var user = await _userAccountService.GetUserById(userId);

            //Validate if not exist
            var rating_exists = await _movieRatingsService.GetRatingByMovieAndUser(id, userId);
            if (movie != null)
                return StatusCode((int)HttpStatusCode.NotModified);

            var rating = await _movieRatingsService.CreateRate(new Ratings()
            {
                Rate = rate,
                RatedMovie = movie,
                RatedBy = user
            });

            return Ok();
        }


        [HttpDelete]
        [Authorize(Policy = RoleConstant.MOVIE_USER_ROLE)]
        public async Task<IActionResult> DeleteRating([FromQuery] int id)
        {
            //Get Rating
            var rating = await _movieRatingsService.GetRatingsById(id);

            if (rating == null)
                return BadRequest("Movie rating does not exist.");

            await _movieRatingsService.DeleteRating(rating);

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Authorize(Policy = RoleConstant.MOVIE_USER_ROLE)]
        public async Task<IActionResult> GetRatings()
        {
            //Get User
            int userId= GetUserClaims.getUserIDFromClaims(HttpContext.User.Identity as ClaimsIdentity);
            var ratings = await _movieRatingsService.GetRatingsByUser(userId);

            return Ok(new Models.Response<List<Ratings>>(ratings));
        }
    }
}
