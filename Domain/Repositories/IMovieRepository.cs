using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieReview.API.Domain.Models;

namespace MovieReview.API.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> ListAsync();
        Task<IEnumerable<Movie>> SearchByTitle(string SearchValue);
        Task<IEnumerable<Movie>> SearchByGenre(string SearchValue);
        Task<IEnumerable<Movie>> SearchByReleaseYear(int SearchYear);
        Task<IEnumerable<Movie>> SearchTopMoviesByReview(int TopRatedMovies);

    }
}
