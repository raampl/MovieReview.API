using MovieReview.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieReview.API.Domain.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> ListAsync();

        Task<IEnumerable<Movie>> SearchByTitle(string SearchValue);

        Task<IEnumerable<Movie>> SearchByGenre(string SearchValue);

        Task<IEnumerable<Movie>> SearchByReleaseYear(int SearchYear);

        Task<IEnumerable<Movie>> SearchTopMoviesByReview(int TopRatedMovies);
    }
}
