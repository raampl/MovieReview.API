using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieReview.API.Domain.Models;
using MovieReview.API.Domain.Repositories;
using MovieReview.API.Domain.Services;

namespace MovieReview.API.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;

        }
        public async Task<IEnumerable<Movie>> ListAsync()
        {
            return await _movieRepository.ListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchByTitle(string SearchValue)
        {
            return await _movieRepository.SearchByTitle(SearchValue);
        }

        public async Task<IEnumerable<Movie>> SearchByGenre(string SearchValue)
        {
            return await _movieRepository.SearchByGenre(SearchValue);
        }

        public async Task<IEnumerable<Movie>> SearchByReleaseYear(int SearchYear)
        {
            return await _movieRepository.SearchByReleaseYear(SearchYear);
        }
    }
}
