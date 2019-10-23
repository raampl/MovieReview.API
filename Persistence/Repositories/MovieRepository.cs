using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReview.API.Domain.Models;
using MovieReview.API.Domain.Repositories;
using MovieReview.API.Persistence.Contexts;

namespace MovieReview.API.Persistence.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Movie>> ListAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        /// <summary>
        /// Search movie title
        /// </summary>
        /// <param name="SearchValue"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> SearchByTitle(string SearchValue)
        {
            return await _context.Movies.Where(m => m.Title.ToLower().Contains(SearchValue.ToLower())).OrderBy(m => m.Title) .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchByGenre(string SearchValue)
        {
            return await _context.Movies.Where(m => m.Genre.ToString().ToLower().Contains(SearchValue.ToLower())).OrderBy(m => m.Title).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchByReleaseYear(int SearchYear)
        {
            return await _context.Movies.Where(m => m.YearOfRelease == SearchYear).OrderBy(m => m.Title).ToListAsync();
        }
    }
}
