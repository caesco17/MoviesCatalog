using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.Core.Helpers;
using MoviesCatalog.Core.Models;
using MoviesCatalog.DataAccess.Data;
using MoviesCatalog.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MoviesCatalog.DataAccess.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _dataContext;
        public MovieService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<Movie> CreateMovie(Movie NewMovie)
        {
            _dataContext.Movies.Add(NewMovie);
            await _dataContext.SaveChangesAsync();

            return NewMovie;
        }

        public async Task<bool> DeleteMovie(Movie Movie)
        {
            _dataContext.Movies.Remove(Movie);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<MovieCategory>> GetAllCategories()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<MovieCategory> GetCategoryByName(string categoryName)
        {
            return await _dataContext.Categories.Where(a => a.Name == categoryName).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieById(int MovieId)
        {
            return await _dataContext.Movies.Where(a => a.MovieId == MovieId).FirstOrDefaultAsync();
        }

        public async Task<Movie> GetMovieByName(string movieName)
        {
            return await _dataContext.Movies.Where(a => a.Name == movieName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovies(PaginationFilter paginationFilter)
        {
            var type = typeof(Movie);
            int _pageNum = paginationFilter.PageNumber;
            int _pageSize = paginationFilter.PageSize;
            IQueryable<Movie> dataset = _dataContext.Movies;
            IOrderedQueryable<Movie>? query = dataset.OrderBy(a=> a.MovieId);

            //Search
            if (!paginationFilter.Name.IsNullOrEmpty())
            {
                dataset = dataset.Where(a => a.Name.Contains(paginationFilter.Name));
            }

            if (!paginationFilter.Synapsis.IsNullOrEmpty())
            {
                dataset = dataset.Where(a => a.Synapsis.Contains(paginationFilter.Synapsis));
            }

            //Filter
            if (!paginationFilter.Category.IsNullOrEmpty())
            {
                dataset = dataset.Where(a => a.Name == paginationFilter.Category);
            }

            if (paginationFilter.ReleaseYear > 0)
            {
                dataset = dataset.Where(a => a.ReleaseYear == paginationFilter.ReleaseYear);
            }


            //Order By
            var OrderBy = paginationFilter.OrderBy.ToString();
            var OrderBy_prop = type.GetProperty(OrderBy);

            if (OrderBy_prop != null)
            {
                var param = Expression.Parameter(type);

                var expr = Expression.Lambda<Func<Movie, object>>(
                    Expression.Convert(Expression.Property(param, OrderBy_prop), typeof(object)),
                    param
                );

                query = dataset.OrderBy(expr);
            }

            //Pagination
            return await query
               .Skip((_pageNum - 1) * _pageSize)
               .Take(_pageSize)
               .ToListAsync();

        }

        public async Task<Movie> UpdateMovie(Movie UpdatedMovie)
        {
            _dataContext.Movies.Update(UpdatedMovie);
            await _dataContext.SaveChangesAsync();

            return UpdatedMovie;
        }
    }
}
