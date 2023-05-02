using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoviesCatalog.Core.Helpers;
using MoviesCatalog.Core.Models;
using MoviesCatalog.DataAccess.Interfaces;
using MoviesCatalog.Web.Auth;
using MoviesCatalog.Web.Models;
using System.Net;
using System.Security.Claims;

namespace MoviesCatalog.Web.Controllers
{
    [Route("Movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IUserAccountService _userAccountService;
        private readonly IMovieService _cachedMovieService;

        public MovieController(IMovieService movieService, IUserAccountService userAccountService, IMovieService cachedMovieService)
        {
            this._movieService = movieService;
            this._userAccountService = userAccountService;
            this._cachedMovieService = cachedMovieService;
        }

        [HttpPost]
        [Authorize(Policy = RoleConstant.MOVIE_ADMIN_ROLE)]
        public async Task<IActionResult> CreateMovie([FromBody] MovieView newMovie)
        {
            //Validate Movie
            var movie = await _movieService.GetMovieByName(newMovie.Name);

            if (movie != null)
                return BadRequest("Movie alredy exists.");

            //Get Category
            var category = await _movieService.GetCategoryByName(newMovie.Categorie);

            if (category == null)
                return BadRequest("Entered Category does not exists.");

            //Get User
            int userId = GetUserClaims.getUserIDFromClaims(HttpContext.User.Identity as ClaimsIdentity);
            var user = await _userAccountService.GetUserById(userId);

            var result = await _movieService.CreateMovie(
                new Core.Models.Movie()
                {
                    Name = newMovie.Name,
                    ReleaseYear = newMovie.ReleaseYear,
                    MovieCategoryId = category.MovieCategoryId,
                    CreatedDate = DateTime.Now,
                    CreatedByAccountId = user.AccountId,
                    Synapsis = newMovie.Synapsis
                });

            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = RoleConstant.MOVIE_ADMIN_ROLE)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
                return BadRequest("Movie does not exists.");

            var result = await _movieService.DeleteMovie(movie);

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPatch]
        [Authorize(Policy = RoleConstant.MOVIE_ADMIN_ROLE)]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieView updateMovie)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
                return BadRequest("Movie does not exists.");

            if(movie.Name != updateMovie.Name)
            {
                var editedMovie = await _movieService.GetMovieByName(updateMovie.Name);

                if (editedMovie != null)
                    return BadRequest("Movie alredy exists.");
            }

            //Get Category
            var category = await _movieService.GetCategoryByName(updateMovie.Categorie);

            if (category == null)
                return BadRequest("Entered Category does not exists.");

            movie.Name = updateMovie.Name;
            movie.ReleaseYear = updateMovie.ReleaseYear;
            movie.MovieCategoryId = category.MovieCategoryId;
            movie.Synapsis = updateMovie.Synapsis;

            var result = await _movieService.UpdateMovie(movie);

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpGet("")]
        [Authorize(Policy = RoleConstant.MOVIE_USER_ROLE)]
        public async Task<IActionResult> GetMovies([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var movies = await _cachedMovieService.GetMovies(filter);

            return Ok(new Models.PagedResponse<IEnumerable<Movie>>(movies, filter.PageNumber, filter.PageSize));
        }

        [HttpGet]
        [Route("Categories")]
        [Authorize(Policy = RoleConstant.MOVIE_USER_ROLE)]
        public async Task<IActionResult> GetCategories()
        {
            var route = Request.Path.Value;
            var movies = await _movieService.GetAllCategories();

            return Ok(new Models.Response<List<MovieCategory>>(movies));
        }
    }
}
